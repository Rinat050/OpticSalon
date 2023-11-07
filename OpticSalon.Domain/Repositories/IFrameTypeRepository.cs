using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface IFrameTypeRepository
    {
        public Task<List<FrameType>> GetAllFrameTypes();
    }
}
