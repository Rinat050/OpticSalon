namespace OpticSalon.Domain.FileStorage
{
    public interface IFileStorage
    {
        public Task UploadFile(string bucketName, string fileName, Stream fileStream);
        public Task<Stream> GetFile(string bucketName, string fileName);
    }
}
