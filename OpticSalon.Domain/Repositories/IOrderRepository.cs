
using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface IOrderRepository
    {
        public Task<int> AddOrder(Order order);
    }
}
