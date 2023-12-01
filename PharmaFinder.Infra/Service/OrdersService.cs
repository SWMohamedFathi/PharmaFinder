﻿using PharmaFinder.Core.Data;
using PharmaFinder.Core.Service;
using PharmaFinder.Core.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
