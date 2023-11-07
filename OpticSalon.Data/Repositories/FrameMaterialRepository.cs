using Microsoft.EntityFrameworkCore;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;

namespace OpticSalon.Data.Repositories
{
    public class FrameMaterialRepository : BaseRepository, IFrameMaterialRepository
    {
        public FrameMaterialRepository(ApplicationContext context) : base(context) { }

        public async Task<List<FrameMaterial>> GetAllFrameMaterials()
        {
            var list = await Context.FrameMaterials
                                .Select(x => Mapper.Map(x))
                                .ToListAsync();

            return list;
        }
    }
}
