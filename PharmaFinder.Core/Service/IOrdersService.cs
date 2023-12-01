﻿using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.Service
{
    public interface IOrdersService
    {
        List<Order> GetAllOrders();
        Order GetOrderById(decimal id);
        void CreateOrder(Order orderData);
        void UpdateOrder(Order orderData);
        void DeleteOrder(decimal id);
        public void AcceptOrRejectOrders(Order order);
        public List<PharmacySalesSearch> SalesSearch(PharmacySalesSearch search);

    }
}
