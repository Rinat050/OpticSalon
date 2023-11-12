using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services.Impl
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<ResultWithData<List<Brand>>> GetAllBrands()
        {
            try
            {
                var res = await _brandRepository.GetAllBrands();

                return new ResultWithData<List<Brand>>()
                {
                    Success = true,
                    Data = res
                };
            }
            catch
            {
                return new ResultWithData<List<Brand>>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }
    }
}
