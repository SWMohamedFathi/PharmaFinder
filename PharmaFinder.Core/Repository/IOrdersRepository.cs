using PharmaFinder.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.Repository
{
    public interface IOrdersRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderById(decimal id);
        void CreateOrder(Order orderData);
        void UpdateOrder(Order orderData);
        void DeleteOrder(decimal id);
    }
}
