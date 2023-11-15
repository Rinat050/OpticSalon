using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface IFrameRepository
    {
        public Task<List<FrameShort>> GetFrames(int? typeId, int? materialId, int? colorId,
                                            int? genderId, int? brandId, ClientPreferences? clientPreferences);

        public Task<Frame?> GetFrameById(int id);
    }
}
