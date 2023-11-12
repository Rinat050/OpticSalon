using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface IBrandRepository
    {
        public Task<List<Brand>> GetAllBrands();
    }
}
