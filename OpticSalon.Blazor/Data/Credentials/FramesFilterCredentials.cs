using OpticSalon.Domain.Models;

namespace OpticSalon.Blazor.Data.Credentials
{
    public class FramesFilterCredentials
    {
        public FrameType Type { get; set; } = null!;
        public FrameMaterial Material { get; set; } = null!;
        public Brand Brand { get; set; } = null!;
        public Gender Gender { get; set; } = null!;
        public Color Color { get; set; } = null!;
        public decimal MinCost { get; set; }
        public decimal MaxCost { get; set; }
        public bool IsClientPrefencesSelected { get; set; }
    }
}
