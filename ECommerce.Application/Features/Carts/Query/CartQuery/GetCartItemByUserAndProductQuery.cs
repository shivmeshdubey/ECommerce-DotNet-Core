using ECommerce.Application.Common;
using ECommerce.Application.DTOs.CartDtos;
using ECommerce.Application.DTOs.CartItemDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Carts.Query.CartQuery
{
    public class GetCartItemByUserAndProductQuery:IRequest<Result<CartItemDto>>
    {
        public  GetCartItemDto dto { get; set; }
        public GetCartItemByUserAndProductQuery(GetCartItemDto dto)
        {
          this.dto = dto;
        }
    }
}
