using System.ComponentModel.DataAnnotations;

namespace OpticSalon.Blazor.Data.Credentials
{
    public class ChangeRoleCredentials
    {
        [Required(ErrorMessage = "Обязательное поле!")]
        public string NewRole { get; set; } = null!;
    }
}
