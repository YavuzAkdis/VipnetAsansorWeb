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
    public class MasterBrandTranslationManager : IMasterBrandTranslationService
    {
        IMasterBrandTranslationDal _masterBrandTranslationDal;

        public MasterBrandTranslationManager(IMasterBrandTranslationDal masterBrandTranslationDal)
        {
            _masterBrandTranslationDal = masterBrandTranslationDal;
        }

        public MasterBrandTranslation GetById(int id)
        {
            return _masterBrandTranslationDal.GetById(id);

        }

        public void TAdd(MasterBrandTranslation t)
        {
           _masterBrandTranslationDal.Insert(t);
        }

        public void TDelete(MasterBrandTranslation t)
        {
          _masterBrandTranslationDal.Delete(t);
        }

        public List<MasterBrandTranslation> TGetList()
        {
           return _masterBrandTranslationDal.GetList();
        }

        public void TUpdate(MasterBrandTranslation t)
        {
            _masterBrandTranslationDal.Update(t);   
        }
    }
}