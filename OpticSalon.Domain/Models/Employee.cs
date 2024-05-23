using System.ComponentModel.DataAnnotations;

namespace OpticSalon.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Обязательное поле!")]
        public string Surname { get; set; } = null!;

        [Required(ErrorMessage = "Обязательное поле!")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "Необходимо 11 символов!")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Обязательное поле!")]
        [MinLength(10, ErrorMessage = "Минимум 10 символов!"),
        MaxLength(150, ErrorMessage = "Максимум 150 символов!")]
        public string Address { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
