using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.Service;

namespace PharmaFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _orderService;

        public OrdersController(IOrdersService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("GetAllOrders")]
        public List<Order> GetAllOrders()
        {
            return _orderService.GetAllOrders();
        }

        [HttpGet]
        [Route("GetOrderById/{id}")]
        public Order GetOrderById(decimal id)
        {
            return _orderService.GetOrderById(id);
        }

        [HttpPost]
        [Route("CreateOrder")]
        public IActionResult CreateOrder(Order order)
        {
            _orderService.CreateOrder(order);
            return StatusCode(201);
        }

        [HttpPut]
        [Route("UpdateOrder/{id}")]
        public IActionResult UpdateOrder(decimal id, Order order)
        {
            order.Orderid = id;
            _orderService.UpdateOrder(order);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteOrder/{id}")]
        public IActionResult DeleteOrder(decimal id)
        {
            _orderService.DeleteOrder(id);
            return Ok();
        }
    }
}
