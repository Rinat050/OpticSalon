using OpticSalon.Domain.Models;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IPurposeService
    {
        public Task<ResultWithData<List<Purpose>>> GetAllPurposes();
    }
}
