using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public virtual ICollection<CartItem> Items { get; set; } = new List<CartItem>();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
