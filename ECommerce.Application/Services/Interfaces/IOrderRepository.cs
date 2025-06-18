using ECommerce.Domain.Entities;
using ECommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> AddOrderAsync(Order order);
        Task<Order?> GetOrderByIdAsync(Guid orderId);
        Task<List<Order>> GetOrdersByUserIdAsync(Guid userId);
        Task<List<Order>> GetAllOrdersAsync(); // For admin
        Task<bool> UpdateOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(Guid orderId);
        Task<bool> UpdateOrderStatusAsync(Guid orderId, OrderStatus newStatus);
    }
}
