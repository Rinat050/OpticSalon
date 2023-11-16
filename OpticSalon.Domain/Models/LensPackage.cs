namespace OpticSalon.Domain.Models
{
    public class LensPackage
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Cost { get; set; }
    }
}
