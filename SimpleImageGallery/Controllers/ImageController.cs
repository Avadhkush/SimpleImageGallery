using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleImageGallery.Data;
using SimpleImageGallery.Services;

namespace SimpleImageGallery.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImage _imageService;
        private IHostingEnvironment _appEnvironment;
        public ImageController(IImage imageService, IHostingEnvironment appEnvironment)
        {
            _imageService = imageService;
            _appEnvironment  = appEnvironment;
        }
        public IActionResult Upload()
        {
            GalleryImage model = new GalleryImage();
            return View(model);
        }

        public async Task<IActionResult> UploadNewImage(IFormFile file, string title, string tags)
        {
            string fileName = string.Empty;
            if(file != null && file.Length != 0)
            {
                var uploads = Path.Combine(_appEnvironment.WebRootPath, "images");
                if (file.Length > 0)
                {
                    fileName = Guid.NewGuid().ToString().Substring(0,10).Replace("-", "") + Path.GetExtension(file.FileName);
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            await _imageService.SetImage(title, tags, fileName);
            return RedirectToAction("Index", "Gallery");
        }
    }
}