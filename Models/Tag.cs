using System;
using System.Collections.Generic;

#nullable disable

namespace Jokizilla.Models.Models
{
    public partial class Tag
    {
        public Tag()
        {
            Taggables = new HashSet<Taggable>();
        }

        public ushort Id { get; set; }
        public string Name { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Taggable> Taggables { get; set; }
    }
}
