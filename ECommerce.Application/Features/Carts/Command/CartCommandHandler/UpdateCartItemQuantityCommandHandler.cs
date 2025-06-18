using ECommerce.Application.Common;
using ECommerce.Application.DTOs.CartDtos;
using ECommerce.Application.Features.Carts.Command.CartCommand;
using ECommerce.Application.Services.Interfaces;
using MediatR;


namespace ECommerce.Application.Features.Carts.Command.CartCommandHandler
{
    public class UpdateCartItemQuantityCommandHandler : IRequestHandler<UpdateCartItemQuantityCommand,Result<string>>
    {
        private readonly ICartService _cartService;
        public UpdateCartItemQuantityCommandHandler(ICartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<Result<string>> Handle(UpdateCartItemQuantityCommand request, CancellationToken cancellationToken)
        {
            // Example implementation logic:  
            // Validate the request DTO  
            if (request.Dto == null)
            {
                return Result<string>.Fail("Invalid request data.");
            }
            var result = await _cartService.UpdateCartItemQuantityAsync(request.Dto);

            // Return success result  
            if(result)
            {
                return Result<string>.Ok("Cart item quantity updated successfully.");
            }
           return Result<string>.Fail("Failed to update cart item quantity. Item may not exist in the cart or invalid quantity specified.");
        }
    }
}
