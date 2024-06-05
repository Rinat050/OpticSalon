using Microsoft.EntityFrameworkCore;
using OpticSalon.Domain.Enums;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;

namespace OpticSalon.Data.Repositories
{
    public class WarrantyRepairRepository : BaseRepository, IWarrantyRepairRepository
    {
        public WarrantyRepairRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<int> AddWarrantyRepair(WarrantyRepair repair)
        {
            var repairDb = Mapper.Map(repair);

            repairDb.CreatedDate = DateTime.SpecifyKind(repairDb.CreatedDate, DateTimeKind.Utc);

            if (repairDb.IssueDate != null)
            {
                repairDb.IssueDate = DateTime.SpecifyKind((DateTime)repairDb.IssueDate, DateTimeKind.Utc);
            }

            await Context.WarrantyRepairs.AddAsync(repairDb);
            await Context.SaveChangesAsync();
            Context.Entry(repairDb).State = EntityState.Detached;

            return repairDb.Id;
        }

        public async Task<List<MasterOrder>> GetMasterRepaires(int masterId)
        {
            var res = await Context.WarrantyRepairs.Where(x => x.MasterId == masterId)
                .Select(x => new MasterOrder()
                {
                    CreatedDate = x.CreatedDate,
                    OrderID = x.Id,
                    OrderType = OrderType.WarrantyRepair,
                    OrderStatus = (OrderStatus)x.Status
                }).ToListAsync();

            return res;
        }

        public async Task<List<MasterOrdersCount>> GetMastersActiveRepairesCount()
        {
            var res = await Context.WarrantyRepairs
                .Include(x => x.Master)
                .Where(x => (OrderStatus)x.Status != OrderStatus.Issued
                        && (OrderStatus)x.Status != OrderStatus.Completed
                        && x.Master.IsActive)
                .GroupBy(x => x.MasterId).Select(x => new MasterOrdersCount()
                {
                    MasterId = x.Key,
                    Count = x.Count()
                })
                .ToListAsync();

            return res;
        }

        public async Task<List<WarrantyRepair>> GetRepairesByOrder(int orderId)
        {
            var list = await Context.WarrantyRepairs
                .Include(x => x.Defect)
                .Include(x => x.Master)
                .Where(x => x.OrderId == orderId)
                .Select(x => Mapper.Map(x))
                .ToListAsync();

            return list;
        }

        public async Task<WarrantyRepair?> GetWarrantyRepairById(int id)
        {
            var repairDb = await Context.WarrantyRepairs
                                .Include(x => x.Master)
                                .Include(x => x.Defect)
                                .Include(x => x.Works)
                                .ThenInclude(x => x.RepairWork)
                                .FirstOrDefaultAsync(x => x.Id == id);
            return repairDb == null ? null : Mapper.Map(repairDb);
        }

        public async Task<List<WarrantyRepairForClient>> GetWarrantyRepairsByClient(int clientId)
        {
            var repaires = await Context.WarrantyRepairs
                        .Include(x => x.Order)
                        .Where(r => r.Order.ClientId == clientId)
                        .OrderByDescending(r => r.CreatedDate)
                        .Select(r => Mapper.MapRepairForClient(r))
                        .ToListAsync();

            return repaires;
        }

        public async Task<List<WarrantyRepairForManager>> GetWarrantyRepairsForManager()
        {
            var repaires = await Context.WarrantyRepairs
                        .Include(x => x.Master)
                        .Select(r => new WarrantyRepairForManager()
                        {
                            Id = r.Id,
                            OrderId = r.OrderId,
                            Master = $"{r.Master.Surname} {r.Master.Name.First()}.",
                            CreatedDate = r.CreatedDate,
                            IssueDate = r.IssueDate,
                            Status = (OrderStatus)r.Status
                        })
                        .OrderByDescending(r => r.CreatedDate)
                        .ToListAsync();

            return repaires;
        }

        public async Task<bool> IsClientRepair(int clientId, int repairId)
        {
            var res = await Context.WarrantyRepairs
                        .Include(x => x.Order)
                        .FirstOrDefaultAsync(x => x.Id == repairId && x.Order.ClientId == clientId);

            return res != null;
        }

        public async Task UpdateWarrantyRepair(WarrantyRepair repair)
        {
            var repairDb = Mapper.Map(repair);

            foreach(var item in repairDb.Works)
            {
                item.RepairWork = null!;
                item.WarrantyRepairId = repair.Id;
            }

            var worksDb = await Context.WarrantyRepairWorks
                .Where(x => x.WarrantyRepairId == repair.Id).ToListAsync();

            foreach(var workDb in worksDb)
            {
                var existWork = repairDb.Works.FirstOrDefault(x => x.Id == workDb.Id);

                if(existWork == null)
                {
                    Context.WarrantyRepairWorks.Remove(workDb);
                }
            }

            repairDb.CreatedDate = DateTime.SpecifyKind(repairDb.CreatedDate, DateTimeKind.Utc);

            if (repairDb.IssueDate != null)
            {
                repairDb.IssueDate = DateTime.SpecifyKind((DateTime)repairDb.IssueDate, DateTimeKind.Utc);
            }

            Context.WarrantyRepairs.Update(repairDb);
            await Context.SaveChangesAsync();

            Context.ChangeTracker.Clear();
        }
    }
}
