using Microsoft.AspNetCore.Mvc;
using OpticSalon.Domain.Services;

namespace OpticSalon.Blazor.Controllers
{
    public class ImageLoadingController : Controller
    {
        private IImageLoadingService _imageLoadingService;

        public ImageLoadingController(IImageLoadingService imageLoadingService)
        {
            _imageLoadingService = imageLoadingService;
        }

        [Route("/getImage")]
        [ResponseCache(Duration = 3600)]
        [HttpGet]
        public async Task<IActionResult> GetImageByName(string name)
        {
            var res = await _imageLoadingService.GetFrameImageAsync(name);

            if (res.Success)
            {
                return File(res.Data!.ContentStream, res.Data!.ContentType);
            }

            return NotFound();
        }
    }
}
