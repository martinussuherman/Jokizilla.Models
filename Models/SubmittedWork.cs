using System;
using System.Collections.Generic;

#nullable disable

namespace Jokizilla.Models.Models
{
    public partial class SubmittedWork
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Message { get; set; }
        public uint? OrderId { get; set; }
        public uint? UserId { get; set; }
        public bool NeedsRevision { get; set; }
        public string CustomerMessage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
    }
}
