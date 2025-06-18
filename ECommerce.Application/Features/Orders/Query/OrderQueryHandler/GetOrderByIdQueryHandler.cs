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
    public class GetOrderByIdQueryHandler:IRequestHandler<GetOrderByIdQuery, Result<OrderResponseDto>>
    {
        private readonly IOrderService _orderService;
        public GetOrderByIdQueryHandler(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }
        
        public async Task<Result<OrderResponseDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
           var result = await _orderService.GetOrderByIdAsync(request.OrderId);
            if (result == null)
            {
                return Result<OrderResponseDto>.Fail("Order not found. Please check the order ID and try again.");
            }
            return Result<OrderResponseDto>.Ok(new OrderResponseDto
            {
                Id = result.Id,
                UserId = result.UserId,
                UserName = result.User?.UserName ?? "Unknown",
                TotalAmount = result.TotalAmount,
                Status = result.Status.ToString(),
                OrderDate = result.OrderDate,
                ShippingAddress = result.ShippingAddress,
                Items = result.Items.Select(item => new OrderItemDto
                {
                    ProductId = item.ProductId,
                    ProductName = item.Product.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                }).ToList()
            });
        }
    }
}
