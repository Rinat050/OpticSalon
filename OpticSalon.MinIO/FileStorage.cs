using Minio;
using Minio.DataModel.Args;
using OpticSalon.Domain.FileStorage;

namespace OpticSalon.MinIO
{
    public class FileStorage : IFileStorage
    {
        private readonly IMinioClient _client;

        public FileStorage(IMinioClient client)
        {
            _client = client;
        }

        public async Task<Stream> GetFileStream(string bucketName, string fileName)
        {
            var memoryStream = new MemoryStream();

            var statArgs = new StatObjectArgs()
                .WithBucket(bucketName)
                .WithObject(fileName);

            var getArgs = new GetObjectArgs()
                .WithBucket(bucketName)
                .WithObject(fileName)
                .WithCallbackStream(x => x.CopyTo(memoryStream));


            var res = await _client.StatObjectAsync(statArgs);
            await _client.GetObjectAsync(getArgs);

            memoryStream.Position = 0;

            return memoryStream;
        }

        public async Task<FileDto> GetFile(string bucketName, string fileName)
        {
            var memoryStream = new MemoryStream();

            var statArgs = new StatObjectArgs()
                .WithBucket(bucketName)
                .WithObject(fileName);

            var getArgs = new GetObjectArgs()
                .WithBucket(bucketName)
                .WithObject(fileName)
                .WithCallbackStream(x => x.CopyTo(memoryStream));


            var res = await _client.StatObjectAsync(statArgs);
            var getResult = await _client.GetObjectAsync(getArgs);

            memoryStream.Position = 0;

            return new FileDto()
            { 
                ContentStream = memoryStream,
                ContentType = res.ContentType
            };
        }

        public async Task UploadFile(string bucketName, string fileName, Stream fileStream)
        {
            var beArgs = new BucketExistsArgs()
                .WithBucket(bucketName);
            bool found = await _client.BucketExistsAsync(beArgs).ConfigureAwait(false);

            if (!found)
            {
                var mbArgs = new MakeBucketArgs()
                    .WithBucket(bucketName);
                await _client.MakeBucketAsync(mbArgs).ConfigureAwait(false);
            }

            var putObjectArgs = new PutObjectArgs()
                .WithBucket(bucketName)
                .WithStreamData(fileStream)
                .WithFileName(fileName);

            await _client.PutObjectAsync(putObjectArgs).ConfigureAwait(false);
        }
    }
}
