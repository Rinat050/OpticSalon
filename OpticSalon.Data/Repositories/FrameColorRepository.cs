using Microsoft.EntityFrameworkCore;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;

namespace OpticSalon.Data.Repositories
{
    public class FrameColorRepository : BaseRepository, IFrameColorRepository
    {
        public FrameColorRepository(ApplicationContext context) : base(context) { }

        public async Task<List<Color>> GetAllFrameColors()
        {
            var list = await Context.Colors
                                .Select(x => Mapper.Map(x))
                                .ToListAsync();

            return list;
        }
    }
}
