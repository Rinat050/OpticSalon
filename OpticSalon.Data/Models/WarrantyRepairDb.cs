namespace OpticSalon.Data.Models
{
    public class WarrantyRepairDb
    {
        public int Id { get; set; }
        public DefectDb Defect { get; set; } = null!;
        public int DefectId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? IssueDate { get; set; } = null!;
        public OrderDb Order { get; set; } = null!;
        public int OrderId { get; set; }
        public EmployeeDb Master { get; set; } = null!;
        public int MasterId { get; set; }
        public int Status { get; set; }
        public string? Comment { get; set; }
        public ICollection<WarrantyRepairWorkDb> Works { get; set; } = new List<WarrantyRepairWorkDb>();
    }
}
