using OpticSalon.Domain.Models;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IFrameColorService
    {
        public Task<ResultWithData<List<Color>>> GetAllFrameColors();
    }
}
