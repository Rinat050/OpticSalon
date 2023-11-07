using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services.Impl
{
    public class FrameColorService : IFrameColorService
    {
        private readonly IFrameColorRepository _frameColorRepository;

        public FrameColorService(IFrameColorRepository repository)
        {
            _frameColorRepository = repository;
        }

        public async Task<ResultWithData<List<Color>>> GetAllFrameColors()
        {
            try
            {
                var result = await _frameColorRepository.GetAllFrameColors();

                return new ResultWithData<List<Color>>()
                {
                    Success = true,
                    Data = result
                };
            }
            catch
            {
                return new ResultWithData<List<Color>>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }
    }
}
