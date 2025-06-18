using ECommerce.Application.Common;
using ECommerce.Application.Features.Category.Command.CommandDef;
using ECommerce.Application.Features.Products.Command.CommandDef;
using ECommerce.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Command.CommandHandler
{
    public  class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<string>>
    {
        private readonly IProductService _productService;
        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<Result<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
           var result = await _productService.DeleteAsync(request.Id);
            if (result)
            {
                return Result<string>.Ok(request.Id.ToString(), "Product deleted successfully");
            }
            return Result<string>.Fail("Product not found");
        }
    }
    
}
