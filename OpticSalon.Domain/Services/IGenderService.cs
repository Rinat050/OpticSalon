using OpticSalon.Domain.Models;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IGenderService
    {
        public Task<ResultWithData<List<Gender>>> GetAllGenders();
    }
}
