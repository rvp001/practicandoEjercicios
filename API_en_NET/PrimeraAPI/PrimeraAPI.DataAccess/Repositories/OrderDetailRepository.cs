using PrimeraAPI.DataAccess.Contracts.Models;
using PrimeraAPI.DataAccess.Contracts.Repositories;
using PrimeraAPI.DataAccess.Mappers;

namespace PrimeraAPI.DataAccess.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private ApplicationDbContext _context;

        public OrderDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<OrderDetailDto> GetOrderDetailsByOrderNumber(int orderNumber)
        {
            var query = from ord in _context.Orderdetails
                        where ord.OrderNumber == orderNumber
                        select OrderDetailMapper.MapOrderDetailDTOfromOrderdetail(ord);

            return query.ToList();
        }

        public OrderDetailDto AddOrderDetail(OrderDetailDto orderDetail)
        {
            var orderDetailInserted = _context.Orderdetails.Add(OrderDetailMapper.MapOrderDetailFromOrderDetailDTO(orderDetail));

            return OrderDetailMapper.MapOrderDetailDTOfromOrderdetail(orderDetailInserted.Entity);
        }

    }
}
