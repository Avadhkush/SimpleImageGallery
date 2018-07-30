using Microsoft.EntityFrameworkCore;
using SimpleImageGallery.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleImageGallery.Services
{
    public class SimpleImageGalleryDbContext : DbContext
    {
        public SimpleImageGalleryDbContext(DbContextOptions options) : base(options)
        { 

        }

        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<ImageTag> ImageTags { get; set; }
    }
}
