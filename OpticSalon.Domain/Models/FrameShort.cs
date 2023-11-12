namespace OpticSalon.Domain.Models
{
    public class FrameShort
    {
        public string Model { get; set; } = null!;
        public decimal Cost { get; set; }
        public Brand Brand { get; set; } = null!;
        public FrameSizes Sizes { get; set; } = null!;
        public string MainImageName { get; set; } = null!;
    }
}
