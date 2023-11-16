namespace OpticSalon.Domain.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public EyeData LeftEye { get; set; } = null!;
        public EyeData RightEye { get; set; } = null!;
        public int Dp { get; set; }
        public Purpose Purpose { get; set; } = null!;
    }
}
