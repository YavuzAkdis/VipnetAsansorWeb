using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class MasterBrand // Ana Firma
    {
        [Key]
        public int MasterBrandID { get; set; }
      
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }
        public string? Url { get; set; }
        // Navigasyon özelliği
        public ICollection<MasterBrandTranslation>? MasterBrandTranslations { get; set; }
    }

}
