namespace PrimeraAPI.DataAccess.Contracts.Models
{
    public class OrderDetailDto
    {
        public int OrderNumber { get; set; }
        public string ProductCode { get; set; } = null!;
        public int QuantityOrdered { get; set; }
        public decimal PriceEach { get; set; }
        public short OrderLineNumber { get; set; }
    }
}
