using System.ComponentModel.DataAnnotations;

namespace OpticSalon.Blazor.Data.Credentials
{
    public class ChangeEmailCredentials
    {
        [Required(ErrorMessage = "Обязательное поле!")]
        [EmailAddress(ErrorMessage = "Необходимо ввести почту!")]
        public string NewEmail { get; set; } = null!;
    }
}
