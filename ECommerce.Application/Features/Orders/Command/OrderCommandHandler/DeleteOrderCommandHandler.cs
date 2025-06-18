using ECommerce.Application.Common;
using ECommerce.Application.Features.Orders.Command.OrderCommand;
using ECommerce.Application.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Orders.Command.OrderCommandHandler
{
    public class DeleteOrderCommandHandler: IRequestHandler<DeleteOrderCommand, Result<string>>
    {
        private readonly IOrderService _orderService;
        public DeleteOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<Result<string>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            // Logic to delete the order by request.OrderId
            // Return appropriate Result<string> based on success or failure
            // For now, we will throw NotImplementedException to indicate that this method is not yet implemented.
            var result = await _orderService.DeleteOrderAsync(request.OrderId);
            if (result)
            {
                return Result<string>.Ok("Order deleted successfully.");
            }
           return Result<string>.Fail("Failed to delete the order. Please try again later.");
            //throw new NotImplementedException("DeleteOrderCommandHandler is not implemented yet.");
        }
    }
}
