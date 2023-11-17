using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services.Impl
{
    public class PurposeService : IPurposeService
    {
        private readonly IPurposeRepository _purposeRepository;

        public PurposeService(IPurposeRepository purposeRepository)
        {
            _purposeRepository = purposeRepository;
        }

        public async Task<ResultWithData<List<Purpose>>> GetAllPurposes()
        {
            try
            {
                var result = await _purposeRepository.GetAll();

                return new ResultWithData<List<Purpose>>()
                {
                    Success = true,
                    Data = result
                };
            }
            catch
            {
                return new ResultWithData<List<Purpose>>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }
    }
}
