using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? Url { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Desciption { get; set; }

        public string? PImageUrl { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsHome { get; set; }

        // İhtiyaca bağlı olarak, dil tabanlı çeviriler için ek bir koleksiyon eklenebilir.
        public ICollection<ProductTranslation>? Translations { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }


    }

}
