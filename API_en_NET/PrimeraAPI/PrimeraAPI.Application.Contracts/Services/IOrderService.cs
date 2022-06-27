using PrimeraAPI.BusinessModels.Models.Order;

namespace PrimeraAPI.Application.Contracts.Services
{
    public interface IOrderService
    {
        OrderWithDetailsResponse? GetOrderWithDetailsByOrderNumber(int orderNumber);
        OrderWithDetailsResponse? SaveOrderWithDetails(CreateOrderWithDetailsRequest request);
    }
}
