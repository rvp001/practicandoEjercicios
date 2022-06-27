using PrimeraAPI.DataAccess.Contracts.Models;

namespace PrimeraAPI.DataAccess.Contracts.Repositories
{
    public interface IOrderRepository
    {
        OrderDto? GetOrderByNumber(int orderNumber);
        OrderDto AddOrder(OrderDto order);
    }

}
