using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AboutTranslation
    {
        [Key]
        public int AboutTranslationID { get; set; }

        public int AboutID { get; set; }

        public string? Language { get; set; } // Örneğin: "en-US" veya "tr-TR"

        public string? TranslatedName { get; set; }
        public string? TranslatedImageUrl { get; set; }
        public string? TranslatedTitle { get; set; }

        public string? TranslatedDescription { get; set; }

        // Navigasyon özelliği
        public About? About { get; set; }
    }

}
