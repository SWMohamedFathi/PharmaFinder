using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.Repository
{
    public interface IOrdersRepository
    {
        public int CalculateTotalOrderPrice();
        public List<SalesSearch2> SalesSearch2(SalesSearch2 search);

        List<GetALLInformationOrders> GetAllInformationOrders();
        List<Order> GetAllOrders();
        Order GetOrderById(decimal id);
        void CreateOrder(Order orderData);
        void UpdateOrder(Order orderData);
        void DeleteOrder(decimal id);
        void AcceptOrRejectOrders(Order order);
        List<PharmacySalesSearch> SalesSearch(PharmacySalesSearch search);
        Task<IEnumerable<MonthlySalesReport>> GetMonthlySalesReport(int month, int year);
        Task<IEnumerable<AnnualSalesReport>> GetAnnualSalesReport(int year);
        Task<IEnumerable<AllSalesByMonthReport>> GetAllSalesByMonthReport(int month, int year);
        Task<IEnumerable<AllSalesByYearReport>> GetAllSalesByYearReport(int year);
        public void ProcessPayment(int OrderdID, Bank bank);

    }
}
