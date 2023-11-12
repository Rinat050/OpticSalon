using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services.Impl
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public async Task<ResultWithData<List<Gender>>> GetAllGenders()
        {
            try
            {
                var res = await _genderRepository.GetAllGenders();

                return new ResultWithData<List<Gender>>()
                {
                    Success = true,
                    Data = res
                };
            }
            catch
            {
                return new ResultWithData<List<Gender>>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }
    }
}
