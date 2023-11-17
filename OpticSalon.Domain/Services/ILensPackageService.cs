using OpticSalon.Domain.Models;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface ILensPackageService
    {
        public Task<ResultWithData<List<LensPackage>>> GetAllLensPackages();
    }
}
