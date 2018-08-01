using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleImageGallery.Data;

namespace SimpleImageGallery.Services
{
    public class ImageService : IImage
    {
        private readonly SimpleImageGalleryDbContext _context;
        public ImageService(SimpleImageGalleryDbContext context)
        {
            _context = context;
        }

        IEnumerable<GalleryImage> IImage.GetAll()
        {
            return _context.GalleryImages.Include(m => m.Tags);
        }

        GalleryImage IImage.GetById(int Id)
        {
            return _context.GalleryImages.Where(t => t.Id == Id).SingleOrDefault();
        }

        IEnumerable<GalleryImage> IImage.GetWithTag(string tag)
        {
            return _context.GalleryImages.Include(m => m.Tags).Where(img => img.Tags.Any(t => t.Description == tag));
        }
    }
}
