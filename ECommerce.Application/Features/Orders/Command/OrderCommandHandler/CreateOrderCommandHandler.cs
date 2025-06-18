using System;
using ECommerce.Application.Common;
using ECommerce.Application.DTOs.Order;
using ECommerce.Application.Features.Orders.Command.OrderCommand;
using ECommerce.Application.Services;
using ECommerce.Application.Services.Interfaces;
using ECommerce.Application.Services.Interfaces.Auth;
using MediatR;

namespace ECommerce.Application.Features.Orders.Command.OrderCommandHandler
{
    public class CreateOrderCommandHandler:IRequestHandler<CreateOrderCommand, Result<OrderResponseDto>>
    {
        private readonly IOrderService _orderService;
        public CreateOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }
        public async Task<Result<OrderResponseDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            if (request.CreateOrderDto == null)
            {
                return Result<OrderResponseDto>.Fail("Order cannot be null");
            }
            var result = await _orderService.CreateOrderAsync(request.CreateOrderDto);
           
            if (result.Success)
            {
                var orderItems = result.Data.Items.Select( (item) =>
                {
                    return new OrderItemDto
                    {
                        ProductId = item.ProductId,
                        ProductName = item.Product.Name,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    };

                }).ToList();
                var orderResponse = new OrderResponseDto
                {
                    Id = result.Data.Id,
                    UserId = result.Data.UserId,
                    UserName = result.Data.User.UserName,
                    TotalAmount = result.Data.TotalAmount,
                    Status = result.Data.Status.ToString(),
                    OrderDate = result.Data.OrderDate,
                    ShippingAddress = result.Data.ShippingAddress,
                    Items = orderItems,
                };
                return Result<OrderResponseDto>.Ok(orderResponse,"Congratulations,your Order Has been placed!");
            }
            return Result<OrderResponseDto>.Fail("Unfortunately ,we are unable to place your Order , please try later....");
        }

    }
}
