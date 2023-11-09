using System.ComponentModel.DataAnnotations;

namespace OpticSalon.Domain.Models
{
    public class ClientPreferences
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public FrameType FrameType { get; set; } = null!;
        [Required(ErrorMessage = "Обязательное поле!")]
        public FrameMaterial FrameMaterial { get; set; } = null!;
        [Required(ErrorMessage = "Обязательное поле!")]
        public Color FrameColor { get; set; } = null!;
         [Required(ErrorMessage = "Обязательное поле!")]
        public FrameSizes FrameSizes { get; set; } = null!;
    }
}
