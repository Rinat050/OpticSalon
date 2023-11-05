namespace OpticSalon.Data.Models
{
    public class ClientPreferencesDb
    {
        public int Id { get; set; }
        public ClientDb Client { get; set; } = null!;
        public int ClientId { get; set; }
        public FrameTypeDb FrameType { get; set; } = null!;
        public int FrameTypeId { get; set; }
        public FrameMaterialDb FrameMaterial { get; set; } = null!;
        public int FrameMaterialId { get; set; }
        public ColorDb FrameColor { get; set; } = null!;
        public int FrameColorId { get; set; }
        public FrameSizesDb FrameSizes { get; set; } = null!;
        public int FrameSizesId { get; set; }
    }
}
