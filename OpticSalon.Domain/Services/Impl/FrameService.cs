using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services.Impl
{
    public class FrameService : IFrameService
    {
        private readonly IFrameRepository _frameRepository;

        public FrameService(IFrameRepository frameRepository)
        {
            _frameRepository = frameRepository;
        }

        public async Task<ResultWithData<List<FrameShort>>> GetAllFrames()
        {
            try
            {
                var result = await _frameRepository.GetFrames(null, null,
                                                null, null, null, null);

                return new ResultWithData<List<FrameShort>>()
                {
                    Success = true,
                    Data = result
                };
            }
            catch
            {
                return new ResultWithData<List<FrameShort>>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }

        public async Task<ResultWithData<List<FrameShort>>> GetAllFrames(int? typeId, int? materialId, 
                                int? colorId, int? genderId, int? brandId, ClientPreferences? clientPreferences)
        {
            try
            {
                var result = await _frameRepository.GetFrames(typeId, materialId,
                                                colorId, genderId, brandId, clientPreferences);

                return new ResultWithData<List<FrameShort>>()
                {
                    Success = true,
                    Data = result
                };
            }
            catch
            {
                return new ResultWithData<List<FrameShort>>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }
    }
}
