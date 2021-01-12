using System;

namespace Jokizilla.Models.ViewModels
{
    public partial class WorkLevelViewDto
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public double PercentageToAdd { get; set; }
        public bool Inactive { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
