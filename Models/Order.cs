using System;
using System.Collections.Generic;

#nullable disable

namespace Jokizilla.Models.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderAdditionalServices = new HashSet<OrderAdditionalService>();
        }

        public uint Id { get; set; }
        public string Number { get; set; }
        public string Title { get; set; }
        public string Instruction { get; set; }
        public uint? CustomerId { get; set; }
        public uint? StaffId { get; set; }
        public ushort? ServiceId { get; set; }
        public byte? WorkLevelId { get; set; }
        public byte? UrgencyId { get; set; }
        public byte? OrderStatusId { get; set; }
        public DateTime? Deadline { get; set; }
        public string UnitName { get; set; }
        public decimal BasePrice { get; set; }
        public decimal WorkLevelPrice { get; set; }
        public decimal UrgencyPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public decimal StaffPaymentPercentage { get; set; }
        public decimal StaffPaymentAmount { get; set; }
        public string SpacingType { get; set; }
        public double WorkLevelPercentage { get; set; }
        public double UrgencyPercentage { get; set; }
        public bool UpdateViaSms { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? InvoicedAt { get; set; }
        public DateTime? ArchivedAt { get; set; }
        public bool Billed { get; set; }

        public virtual User Customer { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual Service Service { get; set; }
        public virtual User Staff { get; set; }
        public virtual Urgency Urgency { get; set; }
        public virtual WorkLevel WorkLevel { get; set; }
        public virtual ICollection<OrderAdditionalService> OrderAdditionalServices { get; set; }
    }
}
