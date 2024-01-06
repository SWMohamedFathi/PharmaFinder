﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
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
        [HttpGet]
        [Route("GetAllOrderMedByOrderID/{id}")]
        public List<GetAllOrderMedsByOrderID> GetAllOrderMedicineByOrderID(decimal id)
        {
            return _orderMedService.GetAllOrderMedicineByOrderID(id);
        }



        [HttpPost]
        [Route("CreateOrdermed")]
        public IActionResult CreateOrdermed(List<PharmaMedResult> orderList,int orderid)
        {
            Ordermed order = new Ordermed();
            foreach (var item in orderList)
            {
                order.Orderid = orderid;
                order.Medicineid = item.Medicineid;
                order.Quantity = item.Quantity;
                _orderMedService.CreateOrdermed(order);

            }

            return StatusCode(201);
        }

        [HttpPut]
        [Route("UpdateOrdermed")]
        public IActionResult UpdateOrdermed( Ordermed ordermed)
        {
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
