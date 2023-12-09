using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using PharmaFinder.Core.Service;
using System.Data;

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

        [HttpPut]
        [Route("AcceptOrRejectOrders")]
        public void AcceptOrRejectOrders(Order order)
        {
            _orderService.AcceptOrRejectOrders(order);

        }


        [HttpPost]
        [Route("SalesSearch")]

        public List<PharmacySalesSearch> SalesSearch(PharmacySalesSearch search)
        {
            return _orderService.SalesSearch(search);
        }

        [HttpPost]
        [Route("MonthlySalesReport")]
       
        public async Task<IEnumerable<MonthlySalesReport>> GetMonthlySalesReport(int month, int year)
        {
            return await _orderService.GetMonthlySalesReport(month,year);

        }

        [HttpPost]
        [Route("AnnualSalesReport")]
        public async Task<IEnumerable<AnnualSalesReport>> GetAnnualSalesReport(int year)
        {
            return await _orderService.GetAnnualSalesReport(year);
        }

        [HttpPost]
        [Route("AllSalesByMonthReport")]
        public async Task<IEnumerable<AllSalesByMonthReport>> GetAllSalesByMonthReport(int month, int year)
        {
            return await _orderService.GetAllSalesByMonthReport(month, year);
        }

        [HttpPost]
        [Route("AllSalesByYearReport")]
        public async Task<IEnumerable<AllSalesByYearReport>> GetAllSalesByYearReport(int year)
        {
            return await _orderService.GetAllSalesByYearReport(year);
        }
    }
}