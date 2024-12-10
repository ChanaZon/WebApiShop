using Entities;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Order order);
        Order GetOrderById(int id);
    }
}