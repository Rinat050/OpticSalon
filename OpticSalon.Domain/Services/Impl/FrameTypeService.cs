using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services.Impl
{
    public class FrameTypeService : IFrameTypeService
    {
        private readonly IFrameTypeRepository _frameTypeRepository;

        public FrameTypeService(IFrameTypeRepository repository)
        {
            _frameTypeRepository = repository;
        }

        public async Task<ResultWithData<List<FrameType>>> GetAllFrameTypes()
        {
            try
            {
                var result = await _frameTypeRepository.GetAllFrameTypes();

                return new ResultWithData<List<FrameType>>()
                {
                    Success = true,
                    Data = result
                };
            }
            catch
            {
                return new ResultWithData<List<FrameType>>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }
    }
}
