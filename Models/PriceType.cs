using System;
using System.Collections.Generic;

#nullable disable

namespace Jokizilla.Models.Models
{
    public partial class PriceType
    {
        public PriceType()
        {
            Services = new HashSet<Service>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
