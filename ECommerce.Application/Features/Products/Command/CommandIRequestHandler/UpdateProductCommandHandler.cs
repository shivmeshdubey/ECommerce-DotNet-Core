using ECommerce.Application.Common;
using ECommerce.Application.Features.Products.Command.CommandDef;
using ECommerce.Application.Services;
using MediatR;

namespace ECommerce.Application.Features.Products.Command.CommandHandler
{
    public class UpdateProductCommandHandler:IRequestHandler<UpdateProductCommand, Result<string>>
    {
        private readonly IProductService _productService;
        public UpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<Result<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {var result = await _productService.UpdateAsync(request.updateProductDto);
            if (result)
            {
                return Result<string>.Ok(request.updateProductDto.Id.ToString(), "Product updated successfully");
            }
            return Result<string>.Fail("Product not found");

        }
    }
}
