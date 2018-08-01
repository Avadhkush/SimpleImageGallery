using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        Task IImage.SetImage(string title, string tags, string fileName)
        {
            GalleryImage image = new GalleryImage()
            {
                Title = title,
                Tags = ParseTags(tags),
                Url = "/images/" + fileName,
                Created = DateTime.Now
            };

            _context.Add(image);
            return _context.SaveChangesAsync();
        }

        private List<ImageTag> ParseTags(string tags)
        {
            List<ImageTag> imageTags = new List<ImageTag>();

            var tagLists = tags.ToString().Split(",");
            foreach (var item in tagLists)
            {
                imageTags.Add(new ImageTag { Description = item });
            }

            return imageTags;
        }
    }
}
