using OpticSalon.Domain.Models;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IDefectService
    {
        public Task<ResultWithData<List<Defect>>> GetAllDefects();
    }
}
