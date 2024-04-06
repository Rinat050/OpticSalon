using Microsoft.EntityFrameworkCore;
using OpticSalon.Domain.Enums;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;

namespace OpticSalon.Data.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<int> AddOrder(Order order)
        {
            var orderDb = Mapper.Map(order);

            orderDb.Recipe.Purpose = null!;
            orderDb.CreatedDate = DateTime.SpecifyKind(orderDb.CreatedDate, DateTimeKind.Utc);
            await Context.Orders.AddAsync(orderDb);
            await Context.SaveChangesAsync();
            Context.Entry(orderDb).State = EntityState.Detached;

            return orderDb.Id;
        }

        public async Task<List<MasterOrder>> GetMasterOrders(int masterId)
        {
            var res = await Context.Orders.Where(x => x.MasterId == masterId)
                .Select(x => new MasterOrder()
                {
                    CreatedDate = x.CreatedDate,
                    OrderID = x.Id,
                    OrderType = OrderType.ManufactureOrder,
                    OrderStatus = (OrderStatus) x.Status
                }).ToListAsync();

            return res;
        }

        public async Task<List<MasterOrdersCount>> GetMastersActiveOrdersCount()
        {
            var res = await Context.Orders
                .Where(x => (OrderStatus)x.Status != OrderStatus.Issued 
                        && (OrderStatus)x.Status != OrderStatus.Completed)
                .GroupBy(x => x.MasterId).Select(x => new MasterOrdersCount()
                {
                    MasterId = x.Key,
                    Count = x.Count()
                })
                .ToListAsync();

            return res;
        }

        public async Task<Order?> GetOrderById(int id)
        {
            var orderDb = await Context.Orders
                        .Include(x => x.LensPackage)
                        .Include(x => x.Client)
                        .Include(x => x.Master)
                        .Include(x => x.Frame.Brand)
                        .Include(x => x.Frame.Material)
                        .Include(x => x.Frame.Gender)
                        .Include(x => x.Frame.Sizes)
                        .Include(x => x.Frame.Type)
                        .Include(x => x.FrameColor)
                        .Include(x => x.Recipe.Purpose)
                        .Include(x => x.Recipe.LeftEye)
                        .Include(x => x.Recipe.RightEye)
                        .FirstOrDefaultAsync(o => o.Id == id);

            return orderDb == null ? null : Mapper.MapOrder(orderDb);
        }

        public async Task<List<OrderShort>> GetOrdersByClient(int clientId)
        {
            var orders = await Context.Orders
                        .Where(o => o.ClientId == clientId)
                        .Select(o => Mapper.MapOrderShort(o))
                        .ToListAsync();

            return orders;
        }

        public async Task UpdateOrder(Order order)
        {
            var orderDb = Mapper.Map(order);
            orderDb.Recipe.Purpose = null!;
            orderDb.CreatedDate = DateTime.SpecifyKind(orderDb.CreatedDate, DateTimeKind.Utc);

            Context.Orders.Update(orderDb);
            await Context.SaveChangesAsync();

            Context.ChangeTracker.Clear();
        }
    }
}
