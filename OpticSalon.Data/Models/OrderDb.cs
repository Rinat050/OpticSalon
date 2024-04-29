namespace OpticSalon.Data.Models
{
    public class OrderDb
    {
        public int Id { get; set; }
        public RecipeDb Recipe { get; set; } = null!;
        public int RecipeId { get; set; }
        public ColorDb FrameColor { get; set; } = null!;
        public int FrameColorId { get; set; }
        public FrameDb Frame { get; set; } = null!;
        public int FrameId { get; set; }
        public LensPackageDb LensPackage { get; set; } = null!;
        public int LensPackageId { get; set; }
        public string ContactPhoneNumber { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public ClientDb Client { get; set; } = null!;
        public int ClientId { get; set; }
        public EmployeeDb Master { get; set; } = null!;
        public int MasterId { get; set; }
        public int Status { get; set; }
        public string? Comment { get; set; }
        public DateTime? IssueDate { get; set; }
    }
}