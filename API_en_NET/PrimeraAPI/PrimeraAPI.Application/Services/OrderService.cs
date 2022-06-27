using PrimeraAPI.Application.Contracts.Services;
using PrimeraAPI.Application.Mappers;
using PrimeraAPI.BusinessModels.Models.Order;
using PrimeraAPI.BusinessModels.Models.OrderDetail;
using PrimeraAPI.DataAccess.Contracts;
using PrimeraAPI.DataAccess.Contracts.Models;
using PrimeraAPI.DataAccess.Contracts.Repositories;

namespace PrimeraAPI.Application.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IUnitOfWork _UoW;
        private IOrderDetailService _orderDetailService;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork UoW, IOrderDetailService orderDetailService)
        {
            _orderRepository = orderRepository;
            _UoW = UoW;
            _orderDetailService = orderDetailService;
        }

        public OrderWithDetailsResponse? GetOrderWithDetailsByOrderNumber(int orderNumber)
        {
            OrderDto? order = _orderRepository.GetOrderByNumber(orderNumber);

            if (order != null)
            {

                List<OrderDetailResponse> orderDetails = _orderDetailService.GetOrderDetailsByOrderNumber(orderNumber);

                OrderWithDetailsResponse result = OrderMapper.MapToOrderWithDetailsResponseFromOrderDtoAndOrderDetailDtoList(order, orderDetails);


                return result;
            }
            else return null;

        }

        public OrderWithDetailsResponse? SaveOrderWithDetails(CreateOrderWithDetailsRequest request)
        {
            OrderDto? existingOrder = _orderRepository.GetOrderByNumber(request.OrderNumber);

            if (existingOrder == null)
            {
                OrderDto orderInserted = _orderRepository.AddOrder(OrderMapper.MapToOrderDtoFromCreateOrderWithDetailsRequest(request));

                List<OrderDetailResponse> orderDetails = _orderDetailService.AddOrderDetailList(request.OrderNumber, request.OrderDetails, false);

                _UoW.Commit();

                return OrderMapper.MapToOrderWithDetailsResponseFromOrderDtoAndOrderDetailDtoList(orderInserted, orderDetails);
            }
            else return null;
        }
    }
}
