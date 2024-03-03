namespace OpticSalon.Domain.FileStorage
{
    public class FileDto
    {
        public Stream ContentStream { get; set; } = null!;
        public string ContentType { get; set; } = "";
    }
}
