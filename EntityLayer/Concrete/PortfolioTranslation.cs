using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PortfolioTranslation
    {
        [Key]
        public int PortfolioTranslationID { get; set; }

        [Required]
        public int PortfolioID { get; set; }
        [ForeignKey("PortfolioID")]
        public Portfolio? Portfolio { get; set; }

        [Required]
        public string? LanguageCode { get; set; } // ISO dil kodu, örn: "en", "tr"
        public string? TranslatedName { get; set; }
        public string? TranslatedTitle { get; set; }
        public string? TranslatedDescription { get; set; }
        public string? TranslatedP1 { get; set; }
        public string? TranslatedP2 { get; set; }
        public string? TranslatedP3 { get; set; }

        public string? TranslatedS1 { get; set; }
        public string? TranslatedSP1 { get; set; }

        public string? TranslatedS2 { get; set; }
        public string? TranslatedSP2 { get; set; }
    }
}
