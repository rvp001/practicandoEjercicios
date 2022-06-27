using PrimeraAPI.BusinessModels.Models.OrderDetail;

namespace PrimeraAPI.Application.Contracts.Services
{
    public interface IOrderDetailService
    {
        List<OrderDetailResponse> GetOrderDetailsByOrderNumber(int orderNumber);
        List<OrderDetailResponse> AddOrderDetailList(int orderNumber, List<CreateOrderDetailRequest> orderDetails, bool commit = true);
    }
}
