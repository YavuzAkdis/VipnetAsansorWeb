
   //Ürünler Sayfasında Diğer Ürünler için Model 

using System.Collections.Generic;
using EntityLayer.Concrete; // Product modelinin bulunduğu namespace

namespace Vipnet_Asansor.Models
{
    public class ProductDetailsViewModel
    {
        public Product CurrentProduct { get; set; }
        public List<Product> OtherProducts { get; set; }
    }
}
