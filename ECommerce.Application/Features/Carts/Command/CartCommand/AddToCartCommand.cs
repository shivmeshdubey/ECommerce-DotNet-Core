using ECommerce.Application.Common;
using ECommerce.Application.DTOs.CartDtos;
using MediatR;

namespace ECommerce.Application.Features.Carts.Command.CartCommand
{
    public class AddToCartCommand :IRequest<Result<string>>
    {
        public AddToCartDto Dto { get; set; }
        public AddToCartCommand(AddToCartDto dto)
        {
            Dto = dto;
        }
    }
}
