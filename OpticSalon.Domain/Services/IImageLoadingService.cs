using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IImageLoadingService
    {
        public Task<BaseResult> UploadFrameImageAsync(Stream fileStream, string fileName);
        public Task<ResultWithData<Stream>> GetFrameImageAsync(string fileName);
    }
}
