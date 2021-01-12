using System;

namespace Jokizilla.Models.ViewModels
{
    public partial class ServiceViewDto
    {
        public ushort Id { get; set; }
        public string Name { get; set; }
        public byte PriceTypeId { get; set; }
        public string PriceTypeName { get; set; }
        public decimal Price { get; set; }
        public decimal SingleSpacingPrice { get; set; }
        public decimal DoubleSpacingPrice { get; set; }
        public bool Inactive { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ushort MinimumOrderQuantity { get; set; }
    }
}
