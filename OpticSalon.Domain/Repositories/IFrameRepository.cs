using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface IFrameRepository
    {
        public Task<List<FrameShort>> GetFrames(int? typeId, int? materialId, int? colorId,
                                            int? genderId, int? brandId, ClientPreferences? clientPreferences,
                                            decimal minCost, decimal maxCost, bool isForAdmin);
        public Task<Frame?> GetFrameById(int id);
        public Task<Frame?> GetFrameByModelAndBrand(string model, int brandId);
        public decimal GetMinFrameCost();
        public decimal GetMaxFrameCost();
        public Task<Frame> AddFrame(Frame frame);
        public Task UpdateFrame(Frame frame);
    }
}
