using System;
using System.Collections.Generic;

#nullable disable

namespace Jokizilla.Models.Models
{
    public partial class Urgency
    {
        public Urgency()
        {
            Orders = new HashSet<Order>();
        }

        public byte Id { get; set; }
        public string Type { get; set; }
        public ushort Value { get; set; }
        public double PercentageToAdd { get; set; }
        public bool Inactive { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
