using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services.Impl
{
    public class RepairWorkService : IRepairWorkService
    {
        private readonly IRepairWorkRepository _repairWorkRepository;

        public RepairWorkService(IRepairWorkRepository repairWorkRepository)
        {
            _repairWorkRepository = repairWorkRepository;
        }

        public async Task<ResultWithData<List<RepairWork>>> GetAllRepairWorks()
        {
            try
            {
                var res = await _repairWorkRepository.GetAllRepairWorks();

                return new ResultWithData<List<RepairWork>>()
                {
                    Success = true,
                    Data = res
                };
            }
            catch
            {
                return new ResultWithData<List<RepairWork>>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }
    }
}
