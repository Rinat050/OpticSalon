using Microsoft.EntityFrameworkCore;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;

namespace OpticSalon.Data.Repositories
{
    public class RepairWorkRepository : BaseRepository, IRepairWorkRepository
    {
        public RepairWorkRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<RepairWork>> GetAllRepairWorks()
        {
            var list = await Context.RepairWorks
                               .Select(x => Mapper.Map(x))
                               .ToListAsync();

            return list;
        }
    }
}
