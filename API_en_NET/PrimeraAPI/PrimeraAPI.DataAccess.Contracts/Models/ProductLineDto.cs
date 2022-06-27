namespace PrimeraAPI.DataAccess.Contracts.Models
{
    public class ProductLineDto
    {
        public string ProductLineCode { get; set; } = null!;
        public string? TextDescription { get; set; }
        public string? HtmlDescription { get; set; }
        public byte[]? Image { get; set; }
    }
}
