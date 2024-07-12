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
    public class Arge
    {
        [Key]
        public int ArgeID { get; set; }

        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Description1 { get; set; }
        public string? Description2 { get; set; }
        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile Image_File { get; set; }
        public string? Name2 { get; set; }
        public string? Description3 { get; set; }

        public string? Description4 { get; set; }
        // Navigasyon özelliği
        public ICollection<ArgeTranslation> ArgeTranslations { get; set; }
    }
}
