using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class MasterBrandTranslation
    {
        [Key]
        public int MasterBrandTranslationID { get; set; }
        public int MasterBrandID { get; set; }
        public string? Language { get; set; }
        public string? TranslatedTitle { get; set; }
        public string? TranslatedName { get; set; }
        public string? TranslatedDescription { get; set; }

        public string? TranslatedImageUrl { get; set; }
        public string? TranslatedUrl { get; set; }
        // Navigasyon özelliği
        public MasterBrand? MasterBrand { get; set; }
    }

}
