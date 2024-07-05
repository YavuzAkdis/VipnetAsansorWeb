using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BrandTranslation
    {
        [Key]
        public int BrandTranslationID { get; set; }

        public int BrandID { get; set; }

        public string? Language { get; set; } // Örneğin: "en-US" veya "tr-TR"

        public string? TranslatedName { get; set; }
        public string? TranslatedTitle { get; set; }
        public string? TranslatedDescription { get; set; }

        public string? TranslatedImageUrl { get; set; }
        public string? TranslatedUrl { get; set; }
        // Navigasyon özelliği
        public Brand? Brand { get; set; }
    }

}
