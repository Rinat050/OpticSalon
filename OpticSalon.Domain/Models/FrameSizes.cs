using OpticSalon.Domain.Consts;
using System.ComponentModel.DataAnnotations;

namespace OpticSalon.Domain.Models
{
    public class FrameSizes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public int LensWidth { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public int DistanceBetweenLens { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public int TempleLenght { get; set; }
    }
}
