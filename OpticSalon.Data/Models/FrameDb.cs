namespace OpticSalon.Data.Models
{
    public class FrameDb
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public string Article { get; set; } = null!;
        public decimal Cost { get; set; }
        public BrandDb Brand { get; set; } = null!;
        public int BrandId { get; set; }
        public FrameSizesDb Sizes { get; set; } = null!;
        public int SizesId { get; set; }
        public FrameMaterialDb Material { get; set; } = null!;
        public int MaterialId { get; set; }
        public FrameTypeDb Type { get; set; } = null!;
        public int TypeId { get; set; }
        public GenderDb Gender { get; set; } = null!;
        public int GenderId { get; set; }
        public ICollection<FrameColorDb> Colors { get; set; } = new List<FrameColorDb>();
    }
}