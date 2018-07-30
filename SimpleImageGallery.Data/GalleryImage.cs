using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleImageGallery.Data
{
    public class GalleryImage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }

        public virtual IEnumerable<ImageTag> Tags { get; set; }
    }
}