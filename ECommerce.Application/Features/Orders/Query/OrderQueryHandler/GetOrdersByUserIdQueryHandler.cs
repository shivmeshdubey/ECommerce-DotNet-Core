using ECommerce.Application.Common;
using ECommerce.Application.DTOs.Order;
using ECommerce.Application.Features.Orders.Query.OrderQuery;
using ECommerce.Application.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Orders.Query.OrderQueryHandler
{
    public class GetOrdersByUserIdQueryHandler:IRequestHandler<GetOrdersByUserIdQuery, Result<List<OrderResponseDto>>>
    {
        private readonly IOrderService _orderService;
        public GetOrdersByUserIdQueryHandler(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        public async Task<Result<List<OrderResponseDto>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _orderService.GetAllOrdersAsync();
            if (result == null)
            {
                return Result<List<OrderResponseDto>>.Fail("Order not found. Please check the order ID and try again.");
            }
            var userOrders = result.Where(o => o.UserId == request.UserId).ToList();
            return Result<List<OrderResponseDto>>.Ok((userOrders.Select(userOrder => new OrderResponseDto
            {
                Id = userOrder.Id,
                UserId = userOrder.UserId,
                UserName = userOrder.User?.UserName,
                TotalAmount = userOrder.TotalAmount,
                Status = userOrder.Status.ToString(),
                OrderDate = userOrder.OrderDate,
                ShippingAddress = userOrder.ShippingAddress,
                Items = userOrder.Items.Select(item => new OrderItemDto
                {
                    ProductId = item.ProductId,
                    ProductName = item.Product.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                }).ToList()
            })).ToList(), "Orders retrieved successfully for the user.");
        }
    }
}
