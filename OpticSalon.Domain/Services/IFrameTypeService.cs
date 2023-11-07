using OpticSalon.Domain.Models;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IFrameTypeService
    {
        public Task<ResultWithData<List<FrameType>>> GetAllFrameTypes();
    }
}
