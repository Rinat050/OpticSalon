using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface IWarrantyRepairRepository
    {
        public Task<int> AddWarrantyRepair(WarrantyRepair repair);
        public Task UpdateWarrantyRepair(WarrantyRepair repair);
        public Task<WarrantyRepair?> GetWarrantyRepairById(int id);
        public Task<List<WarrantyRepairForClient>> GetWarrantyRepairsByClient(int clientId);
        public Task<List<WarrantyRepairForManager>> GetWarrantyRepairsForManager();
        public Task<List<MasterOrder>> GetMasterRepaires(int masterId);
        public Task<List<WarrantyRepair>> GetRepairesByOrder(int orderId);
        public Task<List<MasterOrdersCount>> GetMastersActiveRepairesCount();
    }
}
