namespace OpticSalon.Data.Models
{
    public class ClientDb
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public ICollection<ClientPreferencesDb> Preferences { get; set; } = new List<ClientPreferencesDb>();
        public ICollection<OrderDb> Orders { get; set; } = new List<OrderDb>();
    }
}
