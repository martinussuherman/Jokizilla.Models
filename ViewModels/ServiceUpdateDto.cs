namespace Jokizilla.Models.ViewModels
{
    public partial class ServiceUpdateDto
    {
        public string Name { get; set; }
        public byte PriceTypeId { get; set; }
        public decimal Price { get; set; }
        public decimal SingleSpacingPrice { get; set; }
        public decimal DoubleSpacingPrice { get; set; }
        public bool Inactive { get; set; }
        public ushort MinimumOrderQuantity { get; set; }
    }
}
