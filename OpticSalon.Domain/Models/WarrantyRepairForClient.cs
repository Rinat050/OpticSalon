using OpticSalon.Domain.Enums;

namespace OpticSalon.Domain.Models
{
    public class WarrantyRepairForClient
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; } = null!;
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
