namespace OpticSalon.Data.Models
{
    public class LensPackageDb
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Cost { get; set; }
    }
}
