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
    public class HeaderManager : IHeaderService
    {
        IHeaderDal _headerDal;

        public HeaderManager(IHeaderDal headerDal)
        {
            _headerDal = headerDal;
        }

        public Header GetById(int id)
        {
           return _headerDal.GetById(id);   
        }

        public void TAdd(Header t)
        {
            _headerDal.Insert(t);
        }

        public void TDelete(Header t)
        {
           _headerDal.Delete(t);
        }

        public List<Header> TGetList()
        {
          return _headerDal.GetList();
        }

        public List<Header> GetList(string language)
        {
            Expression<Func<Header, bool>> filter = a => a.Language == language;
            return _headerDal.GetList(filter);
        }

        public void TUpdate(Header t)
        {
            _headerDal.Update(t);  
        }
    }
}
