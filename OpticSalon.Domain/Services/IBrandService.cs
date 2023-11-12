using OpticSalon.Domain.Models;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IBrandService
    {
        public Task<ResultWithData<List<Brand>>> GetAllBrands(); 
    }
}
