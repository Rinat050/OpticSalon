using Microsoft.EntityFrameworkCore;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;

namespace OpticSalon.Data.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Order> AddOrder(Order order)
        {
            var orderDb = Mapper.Map(order);
            await Context.Orders.AddAsync(orderDb);
            await Context.SaveChangesAsync();
            Context.Entry(orderDb).State = EntityState.Detached;

            return Mapper.Map(orderDb);
        }
    }
}
