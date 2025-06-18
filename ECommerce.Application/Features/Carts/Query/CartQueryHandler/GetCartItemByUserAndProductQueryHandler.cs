using ECommerce.Application.Common;
using ECommerce.Application.DTOs.CartDtos;
using ECommerce.Application.Features.Carts.Query.CartQuery;
using ECommerce.Application.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Carts.Query.CartQueryHandler
{
    public class GetCartItemByUserAndProductQueryHandler:IRequestHandler<GetCartItemByUserAndProductQuery, Result<CartItemDto>>   
    {
        private readonly ICartService _cartService;
        public GetCartItemByUserAndProductQueryHandler(ICartService cartServices)
        {
            _cartService = cartServices;
        }
        public async Task<Result<CartItemDto>> Handle(GetCartItemByUserAndProductQuery request, CancellationToken cancellationToken)
        {
            var cartItem = await _cartService.GetCartItemByUserAndProductAsync(request.dto.UserId, request.dto.ProductId);
            if (cartItem == null)
            {
                return Result<CartItemDto>.Fail("Cart item not found.");
            }
            return Result<CartItemDto>.Ok(cartItem);
        }
    }
}
