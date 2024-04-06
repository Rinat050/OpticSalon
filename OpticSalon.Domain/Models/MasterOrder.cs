using OpticSalon.Domain.Enums;

namespace OpticSalon.Domain.Models
{
    public class MasterOrder
    {
        public int OrderID { get; set; }
        public DateTime CreatedDate { get; set; }
        public OrderType OrderType { get; set; }
    }
}
