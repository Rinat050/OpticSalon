using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;
using OpticSalon.Domain.ResultModels;
using OpticSalon.Domain.SuccessMessages;

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
                                                null, null, null, null,
                                                0, int.MaxValue);

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
                                int? colorId, int? genderId, int? brandId, ClientPreferences? clientPreferences,
                                decimal minCost, decimal maxCost)
        {
            try
            {
                var result = await _frameRepository.GetFrames(typeId, materialId,
                                                colorId, genderId, brandId, clientPreferences, minCost, maxCost);

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

        public async Task<ResultWithData<Frame>> GetFrameById(int id)
        {
            try
            {
                var result = await _frameRepository.GetFrameById(id);

                if (result == null)
                {
                    return new ResultWithData<Frame>()
                    {
                        Success = false,
                        Description = FrameServiceMessages.NotFounded
                    };
                }

                return new ResultWithData<Frame>()
                {
                    Success = true,
                    Data = result
                };
            }
            catch
            {
                return new ResultWithData<Frame>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }

        public decimal GetMaxFrameCost()
        {
            try
            {
                return _frameRepository.GetMaxFrameCost();
            }
            catch
            {
                return int.MaxValue;
            }
        }

        public decimal GetMinFrameCost()
        {
            try
            {
                return _frameRepository.GetMinFrameCost();
            }
            catch
            {
                return 0;
            }
        }
    }
}
