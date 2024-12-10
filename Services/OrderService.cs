﻿using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> AddOrder(Order order)
        {
            return await _orderRepository.AddOrder(order);
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id);
        }

    }
}