using System;
using System.Collections.Generic;

#nullable disable

namespace Jokizilla.Models.Models
{
    public partial class Service
    {
        public Service()
        {
            OrderAdditionalServices = new HashSet<OrderAdditionalService>();
            Orders = new HashSet<Order>();
            ServiceTagAdditionalServices = new HashSet<ServiceTagAdditionalService>();
        }

        public ushort Id { get; set; }
        public string Name { get; set; }
        public byte PriceTypeId { get; set; }
        public decimal Price { get; set; }
        public decimal SingleSpacingPrice { get; set; }
        public decimal DoubleSpacingPrice { get; set; }
        public bool Inactive { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ushort MinimumOrderQuantity { get; set; }

        public virtual PriceType PriceType { get; set; }
        public virtual ICollection<OrderAdditionalService> OrderAdditionalServices { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ServiceTagAdditionalService> ServiceTagAdditionalServices { get; set; }
    }
}
