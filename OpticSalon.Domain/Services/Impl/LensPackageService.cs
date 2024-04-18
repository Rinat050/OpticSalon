using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;
using OpticSalon.Domain.ResultModels;
using OpticSalon.Domain.SuccessMessages;

namespace OpticSalon.Domain.Services.Impl
{
    public class LensPackageService : ILensPackageService
    {
        private readonly ILensPackagesRepository _lensPackagesRepository;

        public LensPackageService(ILensPackagesRepository lensPackagesRepository)
        {
            _lensPackagesRepository = lensPackagesRepository;
        }

        public async Task<ResultWithData<LensPackage>> CreateLensPackage(LensPackage lensPackage)
        {
            try
            {
                var existLens = await _lensPackagesRepository.GetLensPackageByName(lensPackage.Name);

                if (existLens != null)
                {
                    return new ResultWithData<LensPackage>()
                    {
                        Success = false,
                        Description = LensPackagesServiceMessages.LensWithThisNameExist
                    };
                }

                var result = await _lensPackagesRepository.AddLensPackage(lensPackage);

                return new ResultWithData<LensPackage>()
                {
                    Success = true,
                    Data = result,
                    Description = LensPackagesServiceMessages.SuccessCreated
                };
            }
            catch
            {
                return new ResultWithData<LensPackage>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
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

        public async Task<BaseResult> UpdateLensPackage(LensPackage lensPackage)
        {
            try
            {
                var existLens = await _lensPackagesRepository.GetLensPackageByName(lensPackage.Name);

                if (existLens != null && existLens.Id != lensPackage.Id)
                {
                    return new ResultWithData<LensPackage>()
                    {
                        Success = false,
                        Description = LensPackagesServiceMessages.LensWithThisNameExist
                    };
                }

                await _lensPackagesRepository.UpdateLensPackage(lensPackage);

                return new BaseResult()
                {
                    Success = true,
                    Description = LensPackagesServiceMessages.SuccessUpdated
                };
            }
            catch
            {
                return new ResultWithData<LensPackage>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }
    }
}
