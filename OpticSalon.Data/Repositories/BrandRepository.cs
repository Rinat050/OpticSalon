using Microsoft.EntityFrameworkCore;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;

namespace OpticSalon.Data.Repositories
{
    public class BrandRepository : BaseRepository, IBrandRepository
    {
        public BrandRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<Brand>> GetAllBrands()
        {
            var list = await Context.Brands
                               .Select(x => Mapper.Map(x))
                               .ToListAsync();

            return list;
        }
    }
}
