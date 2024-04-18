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

        public async Task<LensPackage> AddLensPackage(LensPackage lensPackage)
        {
            var lensDb = Mapper.Map(lensPackage);
            await Context.LensPackages.AddAsync(lensDb);
            await Context.SaveChangesAsync();
            Context.Entry(lensDb).State = EntityState.Detached;

            return Mapper.Map(lensDb);
        }

        public async Task<List<LensPackage>> GetAll()
        {
            var list = await Context.LensPackages
                               .Where(x => !x.IsDeleted)
                               .Select(x => Mapper.Map(x))
                               .ToListAsync();

            return list;
        }

        public async Task<LensPackage?> GetLensPackageByName(string name)
        {
            var result = await Context.LensPackages
                .FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower() && !x.IsDeleted);

            return result != null ? Mapper.Map(result) : null;
        }

        public async Task UpdateLensPackage(LensPackage lensPackage)
        {
            var lensDb = Mapper.Map(lensPackage);
            Context.LensPackages.Update(lensDb);
            await Context.SaveChangesAsync();

            Context.ChangeTracker.Clear();
        }
    }
}
