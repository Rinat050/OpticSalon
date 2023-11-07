using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services.Impl
{
    public class FrameMaterialService : IFrameMaterialService
    {
        private readonly IFrameMaterialRepository _frameMaterialRepository;

        public FrameMaterialService(IFrameMaterialRepository repository)
        {
            _frameMaterialRepository = repository;
        }

        public async Task<ResultWithData<List<FrameMaterial>>> GetAllFrameMaterials()
        {
            try
            {
                var result = await _frameMaterialRepository.GetAllFrameMaterials();

                return new ResultWithData<List<FrameMaterial>>()
                {
                    Success = true,
                    Data = result
                };
            }
            catch
            {
                return new ResultWithData<List<FrameMaterial>>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }
    }
}
