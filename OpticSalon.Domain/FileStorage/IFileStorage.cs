namespace OpticSalon.Domain.FileStorage
{
    public interface IFileStorage
    {
        public Task UploadFile(string bucketName, string fileName, Stream fileStream);
        public Task<Stream> GetFileStream(string bucketName, string fileName);
        public Task<FileDto> GetFile(string bucketName, string fileName);
    }
}
