using Microsoft.EntityFrameworkCore;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;

namespace OpticSalon.Data.Repositories
{
    public class FrameTypeRepository : BaseRepository, IFrameTypeRepository
    {
        public FrameTypeRepository(ApplicationContext context) : base(context) { }

        public async Task<List<FrameType>> GetAllFrameTypes()
        {
            var list = await Context.FrameTypes.Select(x => Mapper.Map(x)).ToListAsync();

            return list;
        }
    }
}
