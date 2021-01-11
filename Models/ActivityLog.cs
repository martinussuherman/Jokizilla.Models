using System;
using System.Collections.Generic;

#nullable disable

namespace Jokizilla.Models.Models
{
    public partial class ActivityLog
    {
        public ulong Id { get; set; }
        public string LogName { get; set; }
        public string Description { get; set; }
        public uint? SubjectId { get; set; }
        public string SubjectType { get; set; }
        public uint? CauserId { get; set; }
        public string CauserType { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
