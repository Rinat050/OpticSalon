using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface IPurposeRepository
    {
        public Task<List<Purpose>> GetAll();
    }
}
