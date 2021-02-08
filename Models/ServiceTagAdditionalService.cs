using System;
using System.Collections.Generic;

#nullable disable

namespace Jokizilla.Models.Models
{
    public partial class ServiceTagAdditionalService
    {
        public ushort ServiceId { get; set; }
        public ushort AdditionalServiceId { get; set; }

        public virtual AdditionalService AdditionalService { get; set; }
        public virtual Service Service { get; set; }
    }
}
