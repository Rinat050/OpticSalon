namespace OpticSalon.Data.Models
{
    public class WarrantyRepairWorkDb
    { 
        public int Id { get; set; }
        public WarrantyRepairDb WarrantyRepair { get; set; } = null!;
        public int WarrantyRepairId { get; set; }
        public RepairWorkDb RepairWork { get; set; } = null!;
        public int RepairWorkId { get; set; }
    }
}