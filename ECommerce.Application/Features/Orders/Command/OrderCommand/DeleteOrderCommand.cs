using ECommerce.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Orders.Command.OrderCommand
{
    public class DeleteOrderCommand:IRequest<Result<string>>
    {
        public Guid OrderId { get; set; }
        public DeleteOrderCommand(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
