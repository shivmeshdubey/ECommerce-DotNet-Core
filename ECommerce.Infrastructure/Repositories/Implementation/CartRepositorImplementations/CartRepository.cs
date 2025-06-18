using ECommerce.Application.DTOs.CartDtos;
using ECommerce.Application.Services.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories.Implementation.CartRepositorImplementations
{
    public class CartRepository: ICartRepository
    {
        public AppDbContext appdbContext { get; set; }
        public CartRepository(AppDbContext appdbContext) { this.appdbContext = appdbContext; }

        public async Task<Cart?> GetCartByUserIdAsync(Guid userId)
        {
            try
            {
                var cart = await appdbContext.Carts
                    .Include(c => c.Items)
                    .ThenInclude(ci => ci.Product)
                    .FirstOrDefaultAsync(c => c.UserId == userId);

                return cart;
            }
            catch
            {
                return null;
            }
        }

        public async Task<CartItem?> GetCartItemAsync(Guid userId, Guid productId)
        {
            try
            {
                var cartItem = await appdbContext.CartItems
                                    .Include(ci => ci.Product)
                                    .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ProductId == productId);
                return cartItem;
            }
            catch
            {
                return null;
            }
        }

        public Task AddCartAsync(Cart cart)
        {
            try
            {
                appdbContext.Carts.Add(cart);
                return appdbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while adding the cart.", ex);
            }
        }

        public async Task UpdateCartAsync(Cart cart)
        {
            try
            {
                appdbContext.Carts.Update(cart);
                appdbContext.Entry(cart).State = EntityState.Modified;
                appdbContext.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("An error occurred while updating the cart.");
            }
            
        }

        public async Task RemoveCartItemAsync(Guid userId, Guid productId)
        {
            try
            {
                await appdbContext.CartItems
               .Where(ci => ci.UserId == userId && ci.ProductId == productId).ExecuteDeleteAsync();
            }
            catch
            {
                throw new Exception("An error occurred while removing the cart item.");
            }
           
        }

        public async Task ClearCartAsync(Guid userId)
        {
            try
            {
                await appdbContext.CartItems
                    .Where(ci => ci.UserId == userId)
                    .ExecuteDeleteAsync();
            }
            catch
            {
                throw new Exception("An error occurred while clearing the cart.");
            }
        }


        public async Task SaveAsync()
        {
            await appdbContext.SaveChangesAsync();
        }

    }
    
}
