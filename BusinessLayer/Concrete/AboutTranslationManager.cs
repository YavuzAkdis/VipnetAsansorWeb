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
    public class AboutTranslationManager : IAboutTranslationService
    {
        IAboutTranslationDal _aboutTranslationDal;

        public AboutTranslationManager(IAboutTranslationDal aboutTranslationDal)
        {
            _aboutTranslationDal = aboutTranslationDal;
        }

        public AboutTranslation GetById(int id)
        {
          return _aboutTranslationDal.GetById(id);
        }

        public void TAdd(AboutTranslation t)
        {
            _aboutTranslationDal.Insert(t);
        }

        public void TDelete(AboutTranslation t)
        {
            _aboutTranslationDal.Delete(t);
        }

        public List<AboutTranslation> TGetList()
        {
           return _aboutTranslationDal.GetList();
        }

        public void TUpdate(AboutTranslation t)
        {
           _aboutTranslationDal.Update(t);
        }
    }
}
