using OpticSalon.Domain.Models;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IRepairWorkService
    {
        public Task<ResultWithData<List<RepairWork>>> GetAllRepairWorks();
    }
}
