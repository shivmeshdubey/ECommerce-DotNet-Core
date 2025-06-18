using ECommerce.Application.Common;
using ECommerce.Application.DTOs.Order;
using ECommerce.Application.Services.Interfaces;
using ECommerce.Application.Services.Interfaces.Auth;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Implementation.OrderServices
{
    public class OrderServices : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserServices _userServices;
        private readonly IProductService _productService;
        public OrderServices(IOrderRepository orderRepository,IUserServices userServices, IProductService productService)
        {
            _orderRepository = orderRepository;
            _userServices = userServices;
            _productService = productService;
        }   
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(Guid id)
        {
            
            return await _orderRepository.GetOrderByIdAsync(id);
        }

        public async Task<Result<Order>> CreateOrderAsync(CreateOrderDto dto)
        {
            // Implementation logic for creating an order
            // Basic validation: ensure user and products exist
            var user = await _userServices.GetUserByIdAsync(dto.UserId);
            if ((user is null))
            {
                return Result<Order>.Fail("Invalid User....");
            }
            var orderItems = new List<OrderItem>();
            foreach (var item in dto.Items)
            {
                var product = await _productService.GetByIdAsync(item.ProductId);
                if (product == null || product.Stock < item.Quantity) return Result<Order>.Fail("Insufficient stock for product: " + product.Name);
                orderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                });
            }

                var order = new Order
                {
                    Id = Guid.NewGuid(),
                    UserId = dto.UserId,
                    Status = OrderStatus.Pending,
                    OrderDate = DateTime.Now,
                    TotalAmount = orderItems.Sum(oi => oi.Quantity * oi.UnitPrice),
                    ShippingAddress = dto.ShippingAddress,
                    Items = orderItems
                };
                var result =  await _orderRepository.AddOrderAsync(order);
                if (result == null)
                {
                    return Result<Order>.Fail("Failed to create order, please try again later.");
                }
                return Result<Order>.Ok(result, "Order created successfully.");
        }

        public async Task<bool> UpdateOrderStatusAsync(UpdateOrderStatusDto dto)
        {
            if(dto == null || dto.Status == OrderStatus.Cancelled) return false;
            return await _orderRepository.UpdateOrderStatusAsync(dto.OrderId, dto.Status);
        }

        public async Task<bool> DeleteOrderAsync(Guid orderId)
        {
            return await _orderRepository.DeleteOrderAsync(orderId);
        }
    }
}
