namespace OpticSalon.Data.Models
{
    public class ClientPreferencesDb
    {
        public int Id { get; set; }
        public ClientDb Client { get; set; } = null!;
        public FrameTypeDb FrameType { get; set; } = null!;
        public FrameMaterialDb FrameMaterial { get; set; } = null!;
        public ColorDb FrameColor { get; set; } = null!;
        public FrameSizesDb FrameSizes { get; set; } = null!;
    }
}
