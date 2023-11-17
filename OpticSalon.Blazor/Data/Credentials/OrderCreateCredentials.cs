using OpticSalon.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace OpticSalon.Blazor.Data.Credentials
{
    public class OrderCreateCredentials
    {
        public int Id { get; set; }
        public Recipe Recipe { get; set; } = null!;
        public Frame Frame { get; set; } = null!;
        public Color FrameColor { get; set; } = null!;
        public LensPackage LensPackage { get; set; } = null!;
        public int LensTintingPercent { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "Необходимо 11 символов!")]
        public string ContactPhoneNumber { get; set; } = null!;
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        public string DeliveryAddress { get; set; } = null!;
        public string? Comment { get; set; }
        public Client Client { get; set; } = null!;
    }
}
