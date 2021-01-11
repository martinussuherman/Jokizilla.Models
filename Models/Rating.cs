using System;
using System.Collections.Generic;

#nullable disable

namespace Jokizilla.Models.Models
{
    public partial class Rating
    {
        public uint Id { get; set; }
        public uint? OrderId { get; set; }
        public uint? UserId { get; set; }
        public byte Number { get; set; }
        public string Comment { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
    }
}
