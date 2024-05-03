using System.ComponentModel.DataAnnotations;

namespace OpticSalon.Blazor.Data.Credentials
{
    public class ClientChangePasswordCredentials
    {
        [Required(ErrorMessage = "Обязательное поле!")]
        public string OldPassword { get; set; } = null!;

        [Required(ErrorMessage = "Обязательное поле!")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
        ErrorMessage = "Пароль должен включать цифры, заглавные, строчные буквы и специальные символы!")]
        public string NewPassword { get; set; } = null!;
    }
}
