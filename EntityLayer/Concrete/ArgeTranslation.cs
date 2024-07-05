using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ArgeTranslation
    {
        [Key]
        public int ArgeTranslationID { get; set; }

        public int ArgeID { get; set; }

        public string? Language { get; set; } // Örneğin: "en-US" veya "tr-TR"

        public string? TranslatedTitle { get; set; }
        public string? TranslatedName { get; set; }
        public string? TranslatedDescription1 { get; set; }
       
        public string? TranslatedDescription2 { get; set; }
        public string? TranslatedImageUrl { get; set; }
        // Navigasyon özelliği
        public Arge? Arge { get; set; }
    }

}
