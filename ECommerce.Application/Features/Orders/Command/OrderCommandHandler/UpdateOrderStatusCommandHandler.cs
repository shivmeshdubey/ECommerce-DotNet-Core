using ECommerce.Application.Common;
using ECommerce.Application.Features.Orders.Command.OrderCommand;
using ECommerce.Application.Services.Interfaces;
using ECommerce.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Orders.Command.OrderCommandHandler
{
    public class UpdateOrderStatusCommandHandler:IRequestHandler<UpdateOrderStatusCommand, Result<string>>
    {
        private readonly IOrderService _orderService;
        public UpdateOrderStatusCommandHandler(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }
        public async Task<Result<string>> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            if (request.UpdateOrderStatatusDto.Status == OrderStatus.Cancelled)
                return Result<string>.Fail("Cannot update status of a cancelled order.");

            var result = await _orderService.UpdateOrderStatusAsync(request.UpdateOrderStatatusDto);
            if (result)
            {
                return Result<string>.Ok("Order status updated successfully.");
            }
            return Result<string>.Fail("Failed to update the order status. Please try again later.");
            
        }
    }
}
