using ECommerce.Application.DTOs.CartDtos;
using ECommerce.Application.DTOs.CartItemDtos;
using ECommerce.Application.Services.Implementation.ProductsServices;
using ECommerce.Application.Services.Interfaces;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Implementation.CartServisesImplimentation
{
    public class CartService : ICartService
    {
        public readonly IProductService _productService;
        public readonly ICartRepository _cartRepository;
        public CartService(IProductService productService, ICartRepository cartRepository)
        {
            _productService = productService;
            _cartRepository = cartRepository;
        }
        public async Task<bool> AddToCartAsync(AddToCartDto dto)
        {
            try
            {
                // Fix: Removed `.Result` and awaited the Task returned by GetByIdAsync  
                var product = await _productService.GetByIdAsync(dto.ProductId);

                if (product == null || product.Stock < dto.Quantity)
                {
                    return false;
                }

                 var cart = await _cartRepository.GetCartByUserIdAsync(dto.UserId);
                if (cart == null)
                {
                    cart = new Cart { UserId = dto.UserId, Items = new List<CartItem>() };
                    await _cartRepository.AddCartAsync(cart);
                }
                var cartItem = await _cartRepository.GetCartItemAsync(dto.UserId, dto.ProductId);
                if(cartItem != null)
                {
                    cartItem.Quantity += dto.Quantity;
                }
                else
                {
                    cartItem = new CartItem
                    {
                        UserId = dto.UserId,
                        ProductId = dto.ProductId,
                        Quantity = dto.Quantity,
                    };
                    cart.Items.Add(cartItem);
                    await _cartRepository.SaveAsync();


                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<bool> CartItemExistsAsync(Guid userId, Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCartAsync(Guid userId)
        {
            try
            {
                await _cartRepository.ClearCartAsync(userId);
                return true;
            }
            catch {
                return false;
            }

             
        }

        public async Task<CartDto> GetCartByUserIdAsync(Guid userId)
        {
            try
            {
                var result = await _cartRepository.GetCartByUserIdAsync(userId);
                if (result != null)
                {
                    return new CartDto
                    {
                        UserId = result.UserId,
                        Items = result.Items.Select(x => new CartItemDto
                        {
                            ProductId = x.ProductId,
                            Quantity = x.Quantity,
                            ProductName = x.Product.Name,
                            Price = x.Product.Price
                        }).ToList()

                    };
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<CartItemDto?> GetCartItemByUserAndProductAsync(Guid userId, Guid productId)
        {
            var result = await _cartRepository.GetCartItemAsync(userId, productId);
            return result is null ? null : new CartItemDto
            {
                ProductId = result.ProductId,
                Quantity = result.Quantity,
                ProductName = result.Product?.Name,
                Price = result.Product?.Price ?? 0
            };
        }

        public async Task<bool> RemoveCartItemAsync(deleteCartItemDto dto)
        {
            try
            {
                await _cartRepository.RemoveCartItemAsync(dto.UserId, dto.ProductId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async  Task<bool> UpdateCartItemQuantityAsync(UpdateCartItemDto dto)
        {
            try
            {
               var cart = await _cartRepository.GetCartByUserIdAsync(dto.UserId);
                if(cart != null)
                {
                    var cartItem = cart.Items.FirstOrDefault( item=>item.ProductId == dto.ProductId);
                    if(cartItem != null)
                    {
                        cartItem.Quantity = dto.Quantity;

                        await _cartRepository.UpdateCartAsync(cart);
                    }

                    return true;

                }
                return false;
            }
            catch
            {
                return false;

            }
        }
    }
}
