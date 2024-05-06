using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface IDefectRepository
    {
        public Task<List<Defect>> GetAllDefects();
    }
}
