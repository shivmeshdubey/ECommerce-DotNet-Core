﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.CartItemDtos
{
    public class GetCartItemDto
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}
