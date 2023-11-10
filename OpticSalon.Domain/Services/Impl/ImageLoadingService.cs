﻿using OpticSalon.Domain.Consts;
using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.FileStorage;
using OpticSalon.Domain.ResultModels;
using OpticSalon.Domain.SuccessMessages;

namespace OpticSalon.Domain.Services.Impl
{
    public class ImageLoadingService : IImageLoadingService
    {
        private readonly IFileStorage _fileStorage;

        public ImageLoadingService(IFileStorage fileStorage)
        {
            _fileStorage = fileStorage;
        }

        public async Task<ResultWithData<Stream>> GetFrameImageAsync(string fileName)
        {
            try
            {
                var res = await _fileStorage.GetFile(ImageStorageConsts.FrameImagesBucket, fileName);

                if (res == null)
                {
                    return new ResultWithData<Stream>()
                    {
                        Success = false,
                        Description = ImageLoadingMessages.NotFounded
                    };
                }

                return new ResultWithData<Stream>()
                {
                    Success = true,
                    Data = res
                };
            }
            catch
            {
                return new ResultWithData<Stream>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }

        public async Task<BaseResult> UploadFrameImageAsync(Stream fileStream, string fileName)
        {
            try
            {
                await _fileStorage.UploadFile(ImageStorageConsts.FrameImagesBucket, fileName, fileStream);

                return new BaseResult()
                {
                    Success = true,
                    Description = ImageLoadingMessages.SuccessUpload
                };
            }
            catch
            {
                return new BaseResult()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }
    }
}
