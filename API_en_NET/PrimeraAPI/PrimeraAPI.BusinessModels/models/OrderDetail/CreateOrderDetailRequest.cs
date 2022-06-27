namespace PrimeraAPI.BusinessModels.Models.OrderDetail
{
    public class CreateOrderDetailRequest
    {
        public string ProductCode { get; set; } = null!;
        public int QuantityOrdered { get; set; }
        public decimal PriceEach { get; set; }
        public short OrderLineNumber { get; set; }
    }
}
