using System;

namespace Jokizilla.Models.ViewModels
{
    public partial class AdditionalServiceViewDto
    {
        public ushort Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public bool Inactive { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
