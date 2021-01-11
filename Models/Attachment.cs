using System;
using System.Collections.Generic;

#nullable disable

namespace Jokizilla.Models.Models
{
    public partial class Attachment
    {
        public uint Id { get; set; }
        public uint? OrderId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public uint? UserId { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
    }
}
