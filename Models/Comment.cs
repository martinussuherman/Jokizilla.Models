using System;
using System.Collections.Generic;

#nullable disable

namespace Jokizilla.Models.Models
{
    public partial class Comment
    {
        public uint Id { get; set; }
        public string Body { get; set; }
        public uint? OrderId { get; set; }
        public uint? UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
    }
}
