using System.ComponentModel.DataAnnotations;

namespace OpticSalon.Blazor.Data.Credentials
{
    public class LoginCredentials
    {
        [Required(ErrorMessage="Обязательное поле!")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Обязательное поле!")]
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; }
    }
}
