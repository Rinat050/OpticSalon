using System.ComponentModel.DataAnnotations;

namespace OpticSalon.Blazor.Data.Credentials
{
    public class ClientRegisterCredentials
    {
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

        [Required(ErrorMessage = "Обязательное поле!")]
        [EmailAddress(ErrorMessage = "Необходимо ввести почту!")]
        public string Login { get; set; } = null!;

        [Required(ErrorMessage = "Обязательное поле!")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", 
        ErrorMessage = "Пароль должен включать цифры, заглавные, строчные буквы и специальные символы!")]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают!")]
        public string PasswordRepeat { get; set; } = null!;
    }
}
