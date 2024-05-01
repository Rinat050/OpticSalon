using OpticSalon.Domain.Enums;

namespace OpticSalon.Domain.Models
{
    public class OrderShortForManager
    {
        public int Id { get; set; }
        public string Client { get; set; } = null!;
        public string Master { get; set; } = null!;
        public OrderStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? IssueDate { get; set; }
    }
}
