namespace OpticSalon.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Recipe Recipe { get; set; } = null!;
        public Frame Frame { get; set; } = null!;
        public LensPackage LensPackage { get; set; } = null!;
        public int LensTintingPercent { get; set; }
        public string ContactPhoneNumber { get; set; } = null!;
        public string DeliveryAddress { get; set; } = null!;
        public string? Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public Client Client { get; set; } = null!;
        public Color FrameColor { get; set; } = null!;
    }
}
