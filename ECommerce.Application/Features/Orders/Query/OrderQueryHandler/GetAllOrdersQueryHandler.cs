using ECommerce.Application.Common;
using ECommerce.Application.DTOs.Order;
using ECommerce.Application.Features.Orders.Query.OrderQuery;
using ECommerce.Application.Services.Interfaces;
using ECommerce.Application.Services.Interfaces.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Orders.Query.OrderQueryHandler
{
    public class GetAllOrdersQueryHandler:IRequestHandler<GetAllOrdersQuery, Result<List<OrderResponseDto>>>
    {
        private readonly IOrderService _orderService;
        public GetAllOrdersQueryHandler(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }
        public async Task<Result<List<OrderResponseDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderService.GetAllOrdersAsync();
            
            if (orders == null || !orders.Any())
            {
                return Result<List<OrderResponseDto>>.Fail("No orders found.");
            }
           
            var orderResponses = orders.Select( order => new OrderResponseDto
            {
                Id = order.Id,
                UserId = order.UserId,
                UserName = order.User.UserName,
                TotalAmount = order.TotalAmount,
                Status = order.Status.ToString(),
                OrderDate = order.OrderDate,
                ShippingAddress = order.ShippingAddress,
                Items = order.Items.Select(item => new OrderItemDto
                {
                    ProductId = item.ProductId,
                    ProductName = item.Product.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                }).ToList()
            }).ToList();
            return Result<List<OrderResponseDto>>.Ok(orderResponses);
        }
    }
}
