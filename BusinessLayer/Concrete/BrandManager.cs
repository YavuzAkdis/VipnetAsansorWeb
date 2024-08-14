using BusinessLayer.Abstract;
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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public Brand GetById(int id)
        {
            return _brandDal.GetById(id);   
        }

        public void TAdd(Brand t)
        {
            _brandDal.Insert(t);
        }

        public void TDelete(Brand t)
        {
            _brandDal.Delete(t);
        }

        public List<Brand> TGetList()
        {
           return _brandDal.GetList();
        }


        public List<Brand> GetList(string language)
        {
            Expression<Func<Brand, bool>> filter = a => a.Language == language;
            return _brandDal.GetList(filter);
        }


        public void TUpdate(Brand t)
        {
           _brandDal.Update(t);
        }
    }
}
