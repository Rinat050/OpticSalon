using Microsoft.EntityFrameworkCore;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;

namespace OpticSalon.Data.Repositories
{
    public class LensPackageRepository : BaseRepository, ILensPackagesRepository
    {
        public LensPackageRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<LensPackage>> GetAll()
        {
            var list = await Context.LensPackages
                               .Select(x => Mapper.Map(x))
                               .ToListAsync();

            return list;
        }
    }
}
