using OpticSalon.Domain.Models;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IFrameMaterialService
    {
        public Task<ResultWithData<List<FrameMaterial>>> GetAllFrameMaterials();
    }
}
