using ECommerce.Application.Common;
using ECommerce.Application.DTOs.CartDtos;
using ECommerce.Application.DTOs.CartItemDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Carts.Command.CartCommand
{
    public class UpdateCartItemQuantityCommand : IRequest<Result<string>>
    {
        public UpdateCartItemDto Dto { get; set; }
        public UpdateCartItemQuantityCommand(UpdateCartItemDto dto)
        {
            Dto = dto;
        }
    }
}
