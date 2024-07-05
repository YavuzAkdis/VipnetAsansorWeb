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
    public class HeaderTranslationManager : IHeaderTranslationService
    {
        IHeaderTranslationDal _headerTranslationDal;

        public HeaderTranslationManager(IHeaderTranslationDal headerTranslationDal)
        {
            _headerTranslationDal = headerTranslationDal;
        }

        public HeaderTranslation GetById(int id)
        {
           return _headerTranslationDal.GetById(id);    
        }

        public void TAdd(HeaderTranslation t)
        {
           _headerTranslationDal.Insert(t);
        }

        public void TDelete(HeaderTranslation t)
        {
            _headerTranslationDal.Delete(t);
        }

        public List<HeaderTranslation> TGetList()
        {
           return _headerTranslationDal.GetList();  
        }

        public void TUpdate(HeaderTranslation t)
        {
           _headerTranslationDal.Update(t);
        }
    }
}
