using ECommerce.Application.Common;
using ECommerce.Application.DTOs.CartDtos;
using ECommerce.Application.Features.Carts.Query.CartQuery;
using ECommerce.Application.Services.Interfaces;
using MediatR;


namespace ECommerce.Application.Features.Carts.Query.CartQueryHandler
{
    public class GetCartByUserIdQueryHandler:IRequestHandler<GetCartByUserIdQuery, Result<CartDto>>
    {
        private readonly ICartService _cartServices;
        public GetCartByUserIdQueryHandler(ICartService cartServices)
        {
            _cartServices = cartServices;
        }
        public async Task<Result<CartDto>> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartServices.GetCartByUserIdAsync(request.UserId);
            if (cart == null)
            {
                return Result<CartDto>.Fail("Cart not found for the specified user.");
            }
            return Result<CartDto>.Ok(cart);
        }
    }
}
