using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface IFrameMaterialRepository
    {
        public Task<List<FrameMaterial>> GetAllFrameMaterials();
    }
}
