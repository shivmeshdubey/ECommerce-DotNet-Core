using ECommerce.Application.DTOs.CartDtos;
using ECommerce.Application.DTOs.CartItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Interfaces
{
    public interface ICartService
    {
        Task<bool> AddToCartAsync(AddToCartDto dto);
        Task<CartDto> GetCartByUserIdAsync(Guid userId);
        Task<bool> RemoveCartItemAsync(deleteCartItemDto dto);
        Task<bool> ClearCartAsync(Guid userId);
        Task<bool> UpdateCartItemQuantityAsync(UpdateCartItemDto dto); // optional
        Task<bool> CartItemExistsAsync(Guid userId, Guid productId); // optional
        Task<CartItemDto> GetCartItemByUserAndProductAsync(Guid userId, Guid productId); // optional

    }


}
