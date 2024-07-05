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
    public class BrandTranslationManager : IBrandTranslationService
    {
        IBrandTranslationDal _brandTranslationDal;

        public BrandTranslationManager(IBrandTranslationDal brandTranslationDal)
        {
            _brandTranslationDal = brandTranslationDal;
        }

        public BrandTranslation GetById(int id)
        {
           return _brandTranslationDal.GetById(id); 
        }

        public void TAdd(BrandTranslation t)
        {
            _brandTranslationDal.Insert(t);
        }

        public void TDelete(BrandTranslation t)
        {
           _brandTranslationDal.Delete(t);
        }

        public List<BrandTranslation> TGetList()
        {
            return _brandTranslationDal.GetList();  
        }

        public void TUpdate(BrandTranslation t)
        {
            _brandTranslationDal.Update(t);
        }
    }
}
