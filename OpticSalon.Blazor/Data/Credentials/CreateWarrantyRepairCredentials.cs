using OpticSalon.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace OpticSalon.Blazor.Data.Credentials
{
    public class CreateWarrantyRepairCredentials
    {
        [Required(ErrorMessage = "Обязательное поле!")]
        public Defect Defect { get; set; } = null!;
        public string? Comment { get; set; }
    }
}
