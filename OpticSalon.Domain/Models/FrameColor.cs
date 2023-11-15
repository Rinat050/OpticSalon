namespace OpticSalon.Domain.Models
{
    public class FrameColor
    {
        public int Id { get; set; }
        public int FrameId { get; set; }
        public Color Color { get; set; } = null!;
    }
}
