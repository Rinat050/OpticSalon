using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services.Impl
{
    public class LensPackageService : ILensPackageService
    {
        private readonly ILensPackagesRepository _lensPackagesRepository;

        public LensPackageService(ILensPackagesRepository lensPackagesRepository)
        {
            _lensPackagesRepository = lensPackagesRepository;
        }

        public async Task<ResultWithData<List<LensPackage>>> GetAllLensPackages()
        {
            try
            {
                var result = await _lensPackagesRepository.GetAll();

                return new ResultWithData<List<LensPackage>>()
                {
                    Success = true,
                    Data = result
                };
            }
            catch
            {
                return new ResultWithData<List<LensPackage>>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }
    }
}
