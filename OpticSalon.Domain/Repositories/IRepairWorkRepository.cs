using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface IRepairWorkRepository
    {
        public Task<List<RepairWork>> GetAllRepairWorks();
    }
}
