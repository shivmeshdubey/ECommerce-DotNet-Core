using ECommerce.Application.Common;
using ECommerce.Application.DTOs.CartItemDtos;
using MediatR;


namespace ECommerce.Application.Features.Carts.Command.CartCommand
{
    public class RemoveCartItemCommand:IRequest<Result<string>>
    {
        public deleteCartItemDto Dto { get; set; }
        public RemoveCartItemCommand(deleteCartItemDto dto)
        {
            Dto = dto;
        }
    }
}
