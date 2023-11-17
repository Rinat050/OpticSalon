using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface ILensPackagesRepository
    {
        public Task<List<LensPackage>> GetAll();
    }
}
