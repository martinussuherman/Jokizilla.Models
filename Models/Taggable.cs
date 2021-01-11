using System;
using System.Collections.Generic;

#nullable disable

namespace Jokizilla.Models.Models
{
    public partial class Taggable
    {
        public uint Id { get; set; }
        public uint? TaggableId { get; set; }
        public string TaggableType { get; set; }
        public ushort? TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
