
using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface IOrderRepository
    {
        public Task<int> AddOrder(Order order);
        public Task UpdateOrder(Order order);
        public Task<Order?> GetOrderById(int id);
        public Task<List<OrderShort>> GetOrdersByClient(int clientId);
        public Task<List<MasterOrdersCount>> GetMastersOrdersCount();
    }
}
