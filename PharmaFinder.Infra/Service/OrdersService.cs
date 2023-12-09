using PharmaFinder.Core.Data;
using PharmaFinder.Core.Service;
using PharmaFinder.Core.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaFinder.Core.DTO;
using Dapper;
using System.Data;

namespace PharmaFinder.Infra.Service
{
    public class OrdersService:IOrdersService
    {
        private readonly IOrdersRepository _orderRepository;

        public OrdersService(IOrdersRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public Order GetOrderById(decimal id)
        {
            return _orderRepository.GetOrderById(id);
        }

        public void CreateOrder(Order orderData)
        {
            _orderRepository.CreateOrder(orderData);
        }

        public void UpdateOrder(Order orderData)
        {
            _orderRepository.UpdateOrder(orderData);
        }

        public void DeleteOrder(decimal id)
        {
            _orderRepository.DeleteOrder(id);
        }
        public void AcceptOrRejectOrders(Order order)
        {
            _orderRepository.AcceptOrRejectOrders(order); 
        }


        public List<PharmacySalesSearch> SalesSearch(PharmacySalesSearch search)
        {
            return _orderRepository.SalesSearch(search);
        }

        public async Task<IEnumerable<MonthlySalesReport>> GetMonthlySalesReport(int month, int year)
        {
            return await _orderRepository.GetMonthlySalesReport(month, year);
        }

        public async Task<IEnumerable<AnnualSalesReport>> GetAnnualSalesReport(int year)
        {
            return await _orderRepository.GetAnnualSalesReport(year);
        }
        public async Task<IEnumerable<AllSalesByMonthReport>> GetAllSalesByMonthReport(int month, int year)
        {
            return await _orderRepository.GetAllSalesByMonthReport(month, year);
        }
        public async Task<IEnumerable<AllSalesByYearReport>> GetAllSalesByYearReport(int year)
        {
            return await _orderRepository.GetAllSalesByYearReport(year);
        }
    }
}
