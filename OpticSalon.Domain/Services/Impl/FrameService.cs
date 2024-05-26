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

        public async Task<ResultWithData<Frame>> CreateFrame(Frame frame)
        {
            try
            {
                var existFrame = await _frameRepository.GetFrameByModelAndBrand(frame.Model, frame.Brand.Id);

                if (existFrame != null)
                {
                    return new ResultWithData<Frame>()
                    {
                        Success = false,
                        Description = FrameServiceMessages.FrameWithThisModelAndBrandExist
                    };
                }

                if (frame.Colors.Count == 0)
                {
                    return new ResultWithData<Frame>()
                    {
                        Success = false,
                        Description = FrameServiceMessages.ColorsNotFounded
                    };
                }

                var result = await _frameRepository.AddFrame(frame);

                return new ResultWithData<Frame>()
                {
                    Success = true,
                    Data = result,
                    Description = FrameServiceMessages.SuccessCreate
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

        public async Task<ResultWithData<List<FrameShort>>> GetAllFrames()
        {
            try
            {
                var result = await _frameRepository.GetFrames(null, null,
                                                null, null, null, null,
                                                0, int.MaxValue, false);

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
                                decimal minCost, decimal maxCost, bool isForAdmin)
        {
            try
            {
                var result = await _frameRepository.GetFrames(typeId, materialId, colorId, genderId, 
                        brandId, clientPreferences, minCost, maxCost, isForAdmin);

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

        public async Task<BaseResult> UpdateFrame(Frame frame)
        {
            try
            {
                var existFrame = await _frameRepository.GetFrameByModelAndBrand(frame.Model, frame.Brand.Id);

                if (existFrame != null && existFrame.Id != frame.Id)
                {
                    return new BaseResult()
                    {
                        Success = false,
                        Description = FrameServiceMessages.FrameWithThisModelAndBrandExist
                    };
                }

                if (frame.Colors.Count == 0)
                {
                    return new BaseResult()
                    {
                        Success = false,
                        Description = FrameServiceMessages.ColorsNotFounded
                    };
                }

                await _frameRepository.UpdateFrame(frame);

                return new BaseResult()
                {
                    Success = true,
                    Description = FrameServiceMessages.SuccessUpdate
                };
            }
            catch
            {
                return new BaseResult()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }
    }
}
