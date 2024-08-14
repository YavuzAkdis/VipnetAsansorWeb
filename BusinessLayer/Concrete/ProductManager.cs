using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id); 
        }

        public void TAdd(Product t)
        {
            _productDal.Insert(t);  
        }

        public void TDelete(Product t)
        {
            _productDal.Delete(t);
        }

        public List<Product> TGetList()
        {
           return _productDal.GetList();
        }


        public List<Product> GetList(string language)
        {
            Expression<Func<Product, bool>> filter = a => a.Language == language;
            return _productDal.GetList(filter);
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
        }

        // Ürünleri Url göre listeleme
        public Product GetByUrl(string url)
        {
            return _productDal.Get(p => p.Url == url);
        }

        public IEnumerable<Product> GetProductsByLanguage(string language)
        {
            return _productDal.GetList(p => p.Language == language);
        }

        public IEnumerable<Product> GetAllProducts() // Bu metod diğer ürünleri almak için kullanılacak
        {
            return _productDal.GetAll();
        }

     
    }
}
