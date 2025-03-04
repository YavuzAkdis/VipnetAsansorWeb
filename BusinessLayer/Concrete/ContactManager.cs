﻿using BusinessLayer.Abstract;
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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public Contact GetById(int id)
        {
           return _contactDal.GetById(id);
        }

        public void TAdd(Contact t)
        {
            _contactDal.Insert(t);
        }

        public void TDelete(Contact t)
        {
           _contactDal.Delete(t);
        }

        public List<Contact> TGetList()
        {
            return _contactDal.GetList();
        }

        public List<Contact> GetList(string language)
        {
            Expression<Func<Contact, bool>> filter = a => a.Language == language;
            return _contactDal.GetList(filter);
        }

        public void TUpdate(Contact t)
        {
           _contactDal.Update(t);   
        }
    }
}
