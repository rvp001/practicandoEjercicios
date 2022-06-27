namespace PrimeraAPI.DataAccess.Contracts.Models
{
    public class OrderDto
    {
        public int OrderNumber { get; set; }
        public DateOnly OrderDate { get; set; }
        public DateOnly RequiredDate { get; set; }
        public DateOnly? ShippedDate { get; set; }
        public string Status { get; set; } = null!;
        public string? Comments { get; set; }
        public int CustomerNumber { get; set; }
    }
}
