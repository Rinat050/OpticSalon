
using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface IOrderRepository
    {
        public Task<Order> AddOrder(Order order);
    }
}
