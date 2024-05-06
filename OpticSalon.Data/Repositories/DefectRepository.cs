using Microsoft.EntityFrameworkCore;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;

namespace OpticSalon.Data.Repositories
{
    public class DefectRepository : BaseRepository, IDefectRepository
    {
        public DefectRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<Defect>> GetAllDefects()
        {
            var list = await Context.Defects
                               .Select(x => Mapper.Map(x))
                               .ToListAsync();

            return list;
        }
    }
}
