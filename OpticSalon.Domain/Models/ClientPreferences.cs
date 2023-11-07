namespace OpticSalon.Domain.Models
{
    public class ClientPreferences
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public FrameType FrameType { get; set; } = null!;
        public FrameMaterial FrameMaterial { get; set; } = null!;
        public Color FrameColor { get; set; } = null!;
        public FrameSizes FrameSizes { get; set; } = null!;
    }
}
