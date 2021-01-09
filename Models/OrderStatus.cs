using System;
using System.Collections.Generic;

#nullable disable

namespace Jokizilla.Models.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public string Badge { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
