using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface IGenderRepository
    {
        public Task<List<Gender>> GetAllGenders();
    }
}
