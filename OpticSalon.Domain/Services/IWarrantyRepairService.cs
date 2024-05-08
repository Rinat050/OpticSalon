using OpticSalon.Domain.Models;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IWarrantyRepairService
    {
        public Task<ResultWithData<int>> CreateRepair(int orderId, Defect defect, string? comment);

        public Task<ResultWithData<List<WarrantyRepairForClient>>> GetRepairesByClient(int clientId);
        public Task<ResultWithData<List<WarrantyRepairForManager>>> GetRepairesForManager();
        public Task<ResultWithData<WarrantyRepair>> GetRepairById(int id);
        public Task<BaseResult> UpdateRepair(WarrantyRepair repair);
        public Task<BaseResult> CanCreateWarrantyRepair(int orderId);
    }
}
