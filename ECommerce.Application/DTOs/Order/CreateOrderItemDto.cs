﻿namespace ECommerce.Application.DTOs.Order
{
    public class CreateOrderItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }

}
