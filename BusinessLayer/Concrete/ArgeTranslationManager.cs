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
    public class ArgeTranslationManager : IArgeTranslationService
    {
        IArgeTranslationDal _argeTranslationDal;

        public ArgeTranslationManager(IArgeTranslationDal argeTranslationDal)
        {
            _argeTranslationDal = argeTranslationDal;
        }

        public ArgeTranslation GetById(int id)
        {
            return _argeTranslationDal.GetById(id); 
        }

        public void TAdd(ArgeTranslation t)
        {
           _argeTranslationDal.Insert(t);
        }

        public void TDelete(ArgeTranslation t)
        {
            _argeTranslationDal.Delete(t);
        }

        public List<ArgeTranslation> TGetList()
        {
            return _argeTranslationDal.GetList();
        }

        public void TUpdate(ArgeTranslation t)
        {
           _argeTranslationDal.Update(t);
        }
    }
}
