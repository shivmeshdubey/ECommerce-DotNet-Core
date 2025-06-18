using ECommerce.Application.Common;
using ECommerce.Application.DTOs.ProductDtos;
using MediatR;

namespace ECommerce.Application.Features.Products.Command.CommandDef
{
    public  class UpdateProductCommand:IRequest<Result<string>>
    {
        public UpdateProductDto updateProductDto { get; set; }
        public UpdateProductCommand(UpdateProductDto updateProductDto)
        {
            this.updateProductDto = updateProductDto;
        }
    }
}
