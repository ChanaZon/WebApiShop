using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {

        MyShopContext _context;
        public OrderRepository(MyShopContext context)
        {
            _context = context;
        }

        public async Task<Order> AddOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public Order GetOrderById(int id)
        {
            Order order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
            if (order == null)
                return null;
            return order;
        }

    }
}
