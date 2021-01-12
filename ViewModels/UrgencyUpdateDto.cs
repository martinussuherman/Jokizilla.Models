namespace Jokizilla.Models.ViewModels
{
    public partial class UrgencyUpdateDto
    {
        public string Type { get; set; }
        public ushort Value { get; set; }
        public double PercentageToAdd { get; set; }
        public bool Inactive { get; set; }
    }
}
