using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services.Impl
{
    public class DefectService : IDefectService
    {
        private readonly IDefectRepository _defectRepository;

        public DefectService(IDefectRepository defectRepository)
        {
            _defectRepository = defectRepository;
        }

        public async Task<ResultWithData<List<Defect>>> GetAllDefects()
        {
            try
            {
                var res = await _defectRepository.GetAllDefects();

                return new ResultWithData<List<Defect>>()
                {
                    Success = true,
                    Data = res
                };
            }
            catch
            {
                return new ResultWithData<List<Defect>>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }
    }
}
