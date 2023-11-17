using Microsoft.EntityFrameworkCore;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;

namespace OpticSalon.Data.Repositories
{
    public class PurposeRepository : BaseRepository, IPurposeRepository
    {
        public PurposeRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<Purpose>> GetAll()
        {
            var list = await Context.Purposes
                               .Select(x => Mapper.Map(x))
                               .ToListAsync();

            return list;
        }
    }
}
