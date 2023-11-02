namespace OpticSalon.Data.Models
{
    public class FrameColorDb
    {
        public int Id { get; set; }
        public FrameDb Frame { get; set; } = null!;
        public ColorDb Color { get; set; } = null!;

    }
}
