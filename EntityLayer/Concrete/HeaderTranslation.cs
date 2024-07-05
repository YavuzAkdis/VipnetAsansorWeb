using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class HeaderTranslation
    {
        [Key]
        public int HeaderTranslationID { get; set; }
        public int HeaderID { get; set; }
        public string? Language { get; set; }
        public string? TranslatedTitle { get; set; }
        public string? TranslatedName { get; set; }
        public string? TranslatedDescription { get; set; }
        public string? TranslatedImageUrl { get; set; }
        public string? TranslatedP1 { get; set; }
        public string? TranslatedP2 { get; set; }
        public string? TranslatedP3 { get; set; }
        public string? TranslatedP4 { get; set; }

        // Navigasyon özelliği
        public Header? Header { get; set; }
    }

}
