using OpticSalon.Domain.Enums;

namespace OpticSalon.Domain.Models
{
    public class WarrantyRepairForManager
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Master { get; set; } = null!;
        public OrderStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? IssueDate { get; set; }
    }
}
