using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Gallery
    {
        [Key]
        public int GalleryID { get; set; }

        public string? Language { get; set; }
        public string? Name { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }


        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? Image_File { get; set; }

       
    }
}
