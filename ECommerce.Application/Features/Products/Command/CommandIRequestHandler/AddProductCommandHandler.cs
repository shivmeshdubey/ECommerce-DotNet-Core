using ECommerce.Application.Common;
using ECommerce.Application.Features.Products.Command.CommandDef;
using ECommerce.Application.Services;
using MediatR;

namespace ECommerce.Application.Features.Products.Command.CommandHandler
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Result<string>>
    {
        private readonly IProductService productService;
        public AddProductCommandHandler(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<Result<string>> Handle(AddProductCommand addProductCommand,CancellationToken cancellationToken)
        {
            var result = await productService.AddAsync(addProductCommand.createProductDto);
            if(result.Success)
            {
                return Result<string>.Ok(result.Data, "Created!");
            }
            return Result<string>.Fail(result.Message);
        }
    }
}
