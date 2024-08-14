using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _abountDal;

        public AboutManager(IAboutDal abountDal)
        {
            _abountDal = abountDal;
        }

        public About GetById(int id)
        {
           return _abountDal.GetById(id);
        }

        public void TAdd(About t)
        {
            _abountDal.Insert(t);
        }

        public void TDelete(About t)
        {
           _abountDal.Delete(t);
        }

        public List<About> TGetList()
        {
            return _abountDal.GetList();
        }

        public List<About> GetList(string language)
        {
            Expression<Func<About, bool>> filter = a => a.Language == language;
            return _abountDal.GetList(filter);
        }

        public void TUpdate(About t)
        {
           _abountDal.Update(t);
        }
    }
}
