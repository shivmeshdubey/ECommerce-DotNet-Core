using ECommerce.Application.Common;
using ECommerce.Application.Features.Carts.Command.CartCommand;
using ECommerce.Application.Services.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Carts.Command.CartCommandHandler
{
    public class AddToCartCommandHandler:IRequestHandler<AddToCartCommand, Result<string>>
    {
        private readonly ICartService _cartService;
        public AddToCartCommandHandler(ICartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<Result<string>> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _cartService.AddToCartAsync(request.Dto);
            if (result)
            {
                return Result<string>.Ok("Item added to cart successfully.");
            }
            return Result<string>.Fail("Failed to add item to cart.");
        }
    }
}
