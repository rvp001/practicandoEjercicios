using PrimeraAPI.BusinessModels.Models.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraAPI.BusinessModels.Models.Order
{
    public class CreateOrderWithDetailsRequest
    {
        public int OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public string RequiredDate { get; set; }
        public string? ShippedDate { get; set; }
        public string Status { get; set; } = null!;
        public string? Comments { get; set; }
        public int CustomerNumber { get; set; }
        public List<CreateOrderDetailRequest> OrderDetails { get; set; }
    }
}
