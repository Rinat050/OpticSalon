namespace OpticSalon.Data.Models
{
    public class RecipeDb
    {
        public int Id { get; set; }
        public EyeDataDb LeftEye { get; set; } = null!;
        public EyeDataDb RightEye { get; set; } = null!;
        public int Dp { get; set; }
        public PurposeDb Purpose { get; set; } = null!;
    }
}
