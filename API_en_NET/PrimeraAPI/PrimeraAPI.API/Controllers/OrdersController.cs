using PrimeraAPI.Application.Contracts.Services;
using PrimeraAPI.BusinessModels.Models.Order;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace PrimeraAPI.API.Controllers
{
    //api/orders
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        //api/orders/{orderNumber}
        [HttpGet]
        [Route("{orderNumber}")]
        [ProducesResponseType(typeof(OrderWithDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetOrderWithDetailsByOrderNumber([Required] int orderNumber)
        {
            OrderWithDetailsResponse? order = _orderService.GetOrderWithDetailsByOrderNumber(orderNumber);

            if (order != null)
            {
                return Ok(order);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrderWithDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SaveOrderWithDetails(CreateOrderWithDetailsRequest request)
        {
            OrderWithDetailsResponse order = _orderService.SaveOrderWithDetails(request);

            if (order != null)
            {
                return Ok(order);
            }
            else
            {
                return Conflict("El pedido ya existe");
            }
        }
    }
}
