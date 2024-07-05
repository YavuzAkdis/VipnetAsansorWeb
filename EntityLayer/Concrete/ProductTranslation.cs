using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProductTranslation
    {
        [Key]
        public int ProductTranslationID { get; set; }
        public int ProductID { get; set; }
        public string? Language { get; set; }
        public string? TranslatedName { get; set; }
        public string? TranslatedDescription { get; set; }

        public string? TranslatedUrl { get; set; }
       
        public string? TranslatedTitle { get; set; }
       

        public string? TranslatedImageUrl { get; set; }
        public bool? TranslatedIsApproved { get; set; }
        public bool? TranslatedIsHome { get; set; }
        // Navigasyon özelliği
        public Product? Product { get; set; }
    }

}
