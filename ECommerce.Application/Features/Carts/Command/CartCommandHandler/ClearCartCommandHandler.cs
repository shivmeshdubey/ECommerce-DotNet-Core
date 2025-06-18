using ECommerce.Application.Common;
using ECommerce.Application.Features.Carts.Command.CartCommand;
using ECommerce.Application.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Carts.Command.CartCommandHandler
{
    public class ClearCartCommandHandler : IRequestHandler<ClearCartCommand, Result<string>>
    {
        private readonly ICartService _cartService;
        public ClearCartCommandHandler(ICartService cartService)
        {
            _cartService = cartService;
        }   
        public async Task<Result<string>> Handle(ClearCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _cartService.ClearCartAsync(request.userId);
            if (result)
            {
                return Result<string>.Ok("Cart cleared successfully.");
            }
            return Result<string>.Fail("Failed to clear cart. Cart may not exist or is already empty.");

        }
    }
}
