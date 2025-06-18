using ECommerce.Application.Common;
using ECommerce.Application.DTOs.CartDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Carts.Query.CartQuery
{
    public class GetCartByUserIdQuery:IRequest<Result<CartDto>>
    {
        public Guid UserId { get; set; }
        public GetCartByUserIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
