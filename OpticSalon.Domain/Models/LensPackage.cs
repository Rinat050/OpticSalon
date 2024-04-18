using System.ComponentModel.DataAnnotations;

namespace OpticSalon.Domain.Models
{
    public class LensPackage
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Обязательное поле!")]
        [MinLength(10, ErrorMessage = "Минимум 10 символов!"),
        MaxLength(500, ErrorMessage = "Максимум 500 символов!")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "Обязательное поле!")]
        public decimal Cost { get; set; }
        public bool IsDeleted { get; set; }
    }
}
