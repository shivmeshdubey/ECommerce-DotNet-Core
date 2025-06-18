using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services.Interfaces
{

    public interface ICartRepository
    {
        Task<Cart> GetCartByUserIdAsync(Guid userId);
        Task<CartItem> GetCartItemAsync(Guid userId, Guid productId);
        Task AddCartAsync(Cart cart);
        Task UpdateCartAsync(Cart cart);
        Task RemoveCartItemAsync(Guid userId, Guid productId);
        Task ClearCartAsync(Guid userId);
        Task SaveAsync(); // optional

    }

}
