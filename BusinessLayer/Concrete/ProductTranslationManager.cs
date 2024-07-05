using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductTranslationManager : IProductTranslationService
    {
        IProductTranslationDal _productTranslationDal;

        public ProductTranslationManager(IProductTranslationDal productTranslationDal)
        {
            _productTranslationDal = productTranslationDal;
        }

        public ProductTranslation GetById(int id)
        {
            return _productTranslationDal.GetById(id);  
        }

        public void TAdd(ProductTranslation t)
        {
           _productTranslationDal.Insert(t);
        }

        public void TDelete(ProductTranslation t)
        {
           _productTranslationDal.Delete(t);
        }

        public List<ProductTranslation> TGetList()
        {
            return _productTranslationDal.GetList();    
        }

        public void TUpdate(ProductTranslation t)
        {
            _productTranslationDal.Update(t);   
        }
    }
}
