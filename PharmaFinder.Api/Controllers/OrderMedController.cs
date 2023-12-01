using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.Repository;
using PharmaFinder.Core.Service;

namespace PharmaFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderMedController : ControllerBase
    {
        private readonly IOrderMedService _orderMedService;

        public OrderMedController(IOrderMedService orderMedService)
        {
            _orderMedService = orderMedService;
        }

        [HttpGet]
        [Route("GetAllOrdermeds")]
        public List<Ordermed> GetAllOrdermeds()
        {
            return _orderMedService.GetAllOrdermeds();
        }

        [HttpGet]
        [Route("GetOrdermedById/{id}")]
        public Ordermed GetOrdermedById(decimal id)
        {
            return _orderMedService.GetOrdermedById(id);
        }

        [HttpPost]
        [Route("CreateOrdermed")]
        public IActionResult CreateOrdermed(Ordermed ordermed)
        {
            _orderMedService.CreateOrdermed(ordermed);
            return StatusCode(201);
        }

        [HttpPut]
        [Route("UpdateOrdermed/{id}")]
        public IActionResult UpdateOrdermed(decimal id, Ordermed ordermed)
        {
            ordermed.Ordermedid = id;
            _orderMedService.UpdateOrdermed(ordermed);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteOrdermed/{id}")]
        public IActionResult DeleteOrdermed(decimal id)
        {
            _orderMedService.DeleteOrdermed(id);
            return Ok();
        }

    }
}
