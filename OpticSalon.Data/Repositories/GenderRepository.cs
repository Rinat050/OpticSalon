using Microsoft.EntityFrameworkCore;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;

namespace OpticSalon.Data.Repositories
{
    public class GenderRepository : BaseRepository, IGenderRepository
    {
        protected GenderRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<Gender>> GetAllGenders()
        {
            var list = await Context.Genders
                               .Select(x => Mapper.Map(x))
                               .ToListAsync();

            return list;
        }
    }
}
