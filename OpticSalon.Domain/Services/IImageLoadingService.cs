using OpticSalon.Domain.FileStorage;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IImageLoadingService
    {
        public Task<BaseResult> UploadFrameImageAsync(Stream fileStream, string fileName);
        public Task<ResultWithData<Stream>> GetFrameImageStreamAsync(string fileName);
        public Task<ResultWithData<FileDto>> GetFrameImageAsync(string fileName);
    }
}
