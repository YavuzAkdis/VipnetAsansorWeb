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
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string? Language { get; set; }
        public string? Url { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Desciption { get; set; }
        public string? Desciption2 { get; set; }
        public string? Desciption3 { get; set; }
        public string? Desciption4 { get; set; }
        public string? PdfFileName { get; set; }
        public string? PdfFileImage { get; set; }
        public string? PdfFileUrl { get; set; }// PDF dosyasının adını saklamak için özellik
        public string? PImageUrl { get; set; }
        public string? PImageUrl2 { get; set; }
        public string? PImageUrl3 { get; set; }

        [NotMapped]
        public IFormFile? PImage_File { get; set; }
        [NotMapped]
        public IFormFile? PImage_File2 { get; set; }
        [NotMapped]
        public IFormFile? PImage_File3 { get; set; }
        [NotMapped]
        public IFormFile? PdfFile { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsHome { get; set; }

          
        public ICollection<ProductCategory>? ProductCategories { get; set; }


    }

}
