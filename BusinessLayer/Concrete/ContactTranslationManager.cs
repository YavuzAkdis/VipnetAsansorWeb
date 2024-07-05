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
    public class ContactTranslationManager : IContactTranslationService
    {
        IContactTranslationDal _contactTranslationDal;

        public ContactTranslationManager(IContactTranslationDal contactTranslation)
        {
            _contactTranslationDal = contactTranslation;
        }

        public ContactTranslation GetById(int id)
        {
           return _contactTranslationDal.GetById(id);   
        }

        public void TAdd(ContactTranslation t)
        {
           _contactTranslationDal.Insert(t);    
        }

        public void TDelete(ContactTranslation t)
        {
           _contactTranslationDal.Delete(t);
        }

        public List<ContactTranslation> TGetList()
        {
           return _contactTranslationDal.GetList();
        }

        public void TUpdate(ContactTranslation t)
        {
            _contactTranslationDal.Update(t);
        }
    }
}
