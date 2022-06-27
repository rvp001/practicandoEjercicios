using PrimeraAPI.BusinessModels.Models.OrderDetail;

namespace PrimeraAPI.BusinessModels.Models.Order
{
    public class OrderWithDetailsResponse
    {
        public int OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public string RequiredDate { get; set; }
        public string? ShippedDate { get; set; }
        public string Status { get; set; } = null!;
        public string? Comments { get; set; }
        public int CustomerNumber { get; set; }
        public List<OrderDetailResponse> OrderDetails { get; set; }
    }
}
