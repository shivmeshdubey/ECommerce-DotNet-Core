using ECommerce.Application.Common;
using ECommerce.Application.DTOs.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Orders.Query.OrderQuery
{
    public class GetAllOrdersQuery : IRequest<Result<List<OrderResponseDto>>>
    {
    }
}
