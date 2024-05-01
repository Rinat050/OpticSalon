using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface IOrderRepository
    {
        public Task<int> AddOrder(Order order);
        public Task UpdateOrder(Order order);
        public Task<Order?> GetOrderById(int id);
        public Task<List<OrderShortForClient>> GetOrdersByClient(int clientId);
        public Task<List<OrderShortForManager>> GetOrdersForManager();
        public Task<List<MasterOrder>> GetMasterOrders(int masterId);
        public Task<List<MasterOrdersCount>> GetMastersActiveOrdersCount();
    }
}
