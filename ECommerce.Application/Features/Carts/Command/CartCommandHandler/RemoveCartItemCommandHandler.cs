using ECommerce.Application.Common;
using ECommerce.Application.Features.Carts.Command.CartCommand;
using ECommerce.Application.Services.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Carts.Command.CartCommandHandler
{
    public class RemoveCartItemCommandHandler : IRequestHandler<RemoveCartItemCommand, Result<string>>
    {
        private readonly ICartService _cartService;
        public RemoveCartItemCommandHandler(ICartService cartService)
        {
            _cartService = cartService;
        }   
        public async Task<Result<string>> Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
        {
            var result = await  _cartService.RemoveCartItemAsync(request.Dto);
            if (result)
            {
                return Result<string>.Ok("Item removed from cart successfully.");
            }
            return Result<string>.Fail("Failed to remove item from cart. Item may not exist in the cart or cart is empty.");
        }
    }
}
