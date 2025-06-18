using ECommerce.Application.Common;
using ECommerce.Application.DTOs.Order;
using ECommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Orders.Query.OrderQuery
{
    public class GetOrderByIdQuery:IRequest<Result<OrderResponseDto>>
    {
        public Guid OrderId { get; set; }
        public GetOrderByIdQuery(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
