using OpticSalon.Domain.Enums;

namespace OpticSalon.Domain.Models
{
    public class OrderShortForClient
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; } = null!;
        public string ContactPhoneNumber { get; set; } = null!;
        public OrderStatus Status { get; set; }
    }
}
