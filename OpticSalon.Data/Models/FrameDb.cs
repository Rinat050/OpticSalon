namespace OpticSalon.Data.Models
{
    public class FrameDb
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public string Article { get; set; } = null!;
        public decimal Cost { get; set; }
        public BrandDb Brand { get; set; } = null!;
        public FrameSizesDb Sizes { get; set; } = null!;
        public FrameMaterialDb Material { get; set; } = null!;
        public FrameTypeDb Type { get; set; } = null!;
        public GenderDb Gender { get; set; } = null!;
    }
}