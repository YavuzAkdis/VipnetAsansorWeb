using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Header // Anasayfa Başlık
    {
        [Key]
        public int HeaderID { get; set; }
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? P1 { get; set; }
        public string? P2 { get; set; }
        public string? P3 { get; set; }
        public string? P4 { get; set; }

        // Navigasyon özelliği
        public ICollection<HeaderTranslation>? HeaderTranslations { get; set; }
    }

}
