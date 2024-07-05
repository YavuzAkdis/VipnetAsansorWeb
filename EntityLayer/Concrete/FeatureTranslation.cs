using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class FeatureTranslation
    {
        [Key]
        public int FeatureTranslationID { get; set; }
        public int FeatureID { get; set; }
        public string? Language { get; set; }
        public string? TranslatedName { get; set; }

        public string? TranslatedTitle { get; set; }
        public string? TranslatedDesciption { get; set; }
        public string? TranslatedVideoUrl { get; set; }

        // Navigasyon özelliği
        public Feature? Feature { get; set; }
    }

}
