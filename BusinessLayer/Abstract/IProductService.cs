using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        // Ürünleri Url göre listeleme
        Product GetByUrl(string url);

        IEnumerable<Product> GetAllProducts(); // Bu metod diğer ürünleri almak için kullanılacak

    }
}
