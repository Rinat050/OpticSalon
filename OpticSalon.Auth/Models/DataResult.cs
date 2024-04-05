namespace OpticSalon.Auth.Models
{
    public class DataResult<T>
    {
        public bool Success { get; set; }
        public string Description { get; set; } = null!;
        public T Data { get; set; }
    }
}
