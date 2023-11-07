using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface IFrameColorRepository
    {
        public Task<List<Color>> GetAllFrameColors();
    }
}
