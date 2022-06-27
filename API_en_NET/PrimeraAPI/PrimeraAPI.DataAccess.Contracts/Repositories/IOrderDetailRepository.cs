using PrimeraAPI.DataAccess.Contracts.Models;


namespace PrimeraAPI.DataAccess.Contracts.Repositories
{
    public interface IOrderDetailRepository
    {
        List<OrderDetailDto> GetOrderDetailsByOrderNumber(int orderNumber);
        OrderDetailDto AddOrderDetail(OrderDetailDto orderDetail);
    }
}
