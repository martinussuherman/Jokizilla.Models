using System;
using System.Collections.Generic;

#nullable disable

namespace Jokizilla.Models.Models
{
    public partial class OrderAdditionalService
    {
        public uint Id { get; set; }
        public uint? OrderId { get; set; }
        public ushort? ServiceId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }

        public virtual Order Order { get; set; }
        public virtual Service Service { get; set; }
    }
}
