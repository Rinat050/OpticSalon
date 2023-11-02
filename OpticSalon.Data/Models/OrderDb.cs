namespace OpticSalon.Data.Models
{
    public class OrderDb
    {
        public int Id { get; set; }
        public RecipeDb Recipe { get; set; } = null!;
        public FrameDb Frame { get; set; } = null!;
        public LensPackageDb LensPackage { get; set; } = null!;
        public int LensTintingPercent { get; set; }
        public string ContactPhoneNumber { get; set; } = null!;
        public string DeliveryAddress { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
    }
}
