using OpticSalon.Domain.Enums;

namespace OpticSalon.Domain.Models
{
    public class WarrantyRepair
    {
        public int Id { get; set; }
        public Defect Defect { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? IssueDate { get; set; } = null!;
        public int OrderId { get; set; }
        public Employee Master { get; set; } = null!;
        public OrderStatus Status { get; set; }
        public string? Comment { get; set; }
        public ICollection<WarrantyRepairWork> Works { get; set; } = new List<WarrantyRepairWork>();
    }
}
