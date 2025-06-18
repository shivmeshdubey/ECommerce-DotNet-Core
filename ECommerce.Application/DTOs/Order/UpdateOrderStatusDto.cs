using ECommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.Order
{
    public class UpdateOrderStatusDto
    {
        public Guid OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
