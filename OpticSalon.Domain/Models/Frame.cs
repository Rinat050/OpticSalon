using System.ComponentModel.DataAnnotations;

namespace OpticSalon.Domain.Models
{
    public class Frame
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public string Model { get; set; } = null!;
        [Required(ErrorMessage = "Обязательное поле!")]
        [Range(1, int.MaxValue, ErrorMessage = "Стоимость должна быть больше 0!")]
        public decimal Cost { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public Brand Brand { get; set; } = null!;
        public FrameSizes Sizes { get; set; } = null!;
        [Required(ErrorMessage = "Обязательное поле!")]
        public FrameMaterial Material { get; set; } = null!;
        [Required(ErrorMessage = "Обязательное поле!")]
        public FrameType Type { get; set; } = null!;
        [Required(ErrorMessage = "Обязательное поле!")]
        public Gender Gender { get; set; } = null!;
        public string MainImageName { get; set; } = null!;
        public ICollection<FrameColor> Colors { get; set; } = new List<FrameColor>();
    }
}
