using ECommerce.Application.Common;
using ECommerce.Application.DTOs.Order;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(Guid id);
        Task<Result<Order>> CreateOrderAsync(CreateOrderDto dto);
        Task<bool> UpdateOrderStatusAsync(UpdateOrderStatusDto dto);
        Task<bool> DeleteOrderAsync(Guid orderId);
    }
}
