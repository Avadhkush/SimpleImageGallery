using SimpleImageGallery.Data;
using System.Collections.Generic;

namespace SimpleImageGallery.Services
{
    public interface IImage
    {
        IEnumerable<GalleryImage> GetAll();
        IEnumerable<GalleryImage> GetWithTag(string tag);
        GalleryImage GetById(int Id);
    }
}