using SimpleImageGallery.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleImageGallery.Services
{
    public interface IImage
    {
        IEnumerable<GalleryImage> GetAll();
        IEnumerable<GalleryImage> GetWithTag(string tag);
        GalleryImage GetById(int Id);
        Task SetImage(string title, string tags, string fileName);
    }
}