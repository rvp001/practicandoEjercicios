using System.ComponentModel.DataAnnotations;

namespace PrimeraAPI.BusinessModels.models.Product
{
    public class UpdateProductRequest
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Line { get; set; } = null!;
        [Required]
        public string Scale { get; set; } = null!;
        [Required]
        public string Vendor { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public short Stock { get; set; }
        [Required]
        public decimal BuyPrice { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
