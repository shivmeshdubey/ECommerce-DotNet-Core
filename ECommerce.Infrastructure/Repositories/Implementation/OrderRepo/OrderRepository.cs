using ECommerce.Application.Services.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enum;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories.Implementation.OrderRepo
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
           var result = await _appDbContext.Orders.AddAsync(order);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Order?> GetOrderByIdAsync(Guid orderId)
        {
            // Implementation for retrieving an order by ID  
            try
            {
                var result = await _appDbContext.Orders
                    .Include(o =>o.User)
                    .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                    .FirstOrDefaultAsync(o => o.Id == orderId);
                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(Guid userId)
        {
            try
            {
                var result = await _appDbContext.Orders.Include(o => o.User)
                    .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                    .Where(o => o.UserId == userId)
                    .ToListAsync();
                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            var result = await _appDbContext.Orders
                .Include(o=>o.User)
                .Include(o => o.Items)
                .ThenInclude(oi => oi.Product)
                .ToListAsync();
            return result;
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            return _appDbContext.Orders.Update(order) != null && await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteOrderAsync(Guid orderId)
        {
           var result = await _appDbContext.Orders.Where(o=>o.Id==orderId).ExecuteDeleteAsync();
            return result>0;
        }
        public async Task<bool> UpdateOrderStatusAsync(Guid orderId, OrderStatus newStatus)
        {
            var order = await _appDbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            if (order == null) return false;

            order.Status = newStatus;
            _appDbContext.Orders.Update(order);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

    }
}
