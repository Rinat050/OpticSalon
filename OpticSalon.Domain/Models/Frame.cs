namespace OpticSalon.Domain.Models
{
    public class Frame
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public decimal Cost { get; set; }
        public Brand Brand { get; set; } = null!;
        public FrameSizes Sizes { get; set; } = null!;
        public FrameMaterial Material { get; set; } = null!;
        public FrameType Type { get; set; } = null!;
        public Gender Gender { get; set; } = null!;
        public string MainImageName { get; set; } = null!;
        public ICollection<Color> Colors { get; set; } = new List<Color>();
    }
}
