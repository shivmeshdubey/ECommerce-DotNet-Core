using ECommerce.Application.Common;
using ECommerce.Application.DTOs.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Orders.Command.OrderCommand
{
    public class UpdateOrderStatusCommand:IRequest<Result<string>>
    {
        public UpdateOrderStatusDto UpdateOrderStatatusDto { get; set; }
        public UpdateOrderStatusCommand(UpdateOrderStatusDto updateOrderStatatusDto)
        {
            UpdateOrderStatatusDto = updateOrderStatatusDto ?? throw new ArgumentNullException(nameof(updateOrderStatatusDto));
        }

    }
}
