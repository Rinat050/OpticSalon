using OpticSalon.Domain.Models;

namespace OpticSalon.Blazor.Data.Credentials
{
    public class OrderCreateCredentials
    {
        public int Id { get; set; }
        public Recipe Recipe { get; set; } = null!;
        public Frame Frame { get; set; } = null!;
        public LensPackage LensPackage { get; set; } = null!;
        public int LensTintingPercent { get; set; }
        public string ContactPhoneNumber { get; set; } = null!;
        public string DeliveryAddress { get; set; } = null!;
    }
}
