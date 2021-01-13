using System;

namespace Jokizilla.Models.ViewModels
{
    public class UrgencyViewDto
    {
        public byte Id { get; set; }
        public string Type { get; set; }
        public ushort Value { get; set; }
        public double PercentageToAdd { get; set; }
        public bool Inactive { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
