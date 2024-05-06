namespace OpticSalon.Domain.Models
{
    public class WarrantyRepairWork
    {
        public int Id { get; set; }
        public int WarrantyId { get; set; }
        public RepairWork RepairWork { get; set; }
    }
}
