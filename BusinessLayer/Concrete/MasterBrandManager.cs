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
    public class MasterBrandManager : IMasterBrandService
    {
        IMasterBrandDal _masterBrandDal;

        public MasterBrandManager(IMasterBrandDal masterBrandDal)
        {
            _masterBrandDal = masterBrandDal;
        }

        public MasterBrand GetById(int id)
        {
            return _masterBrandDal.GetById(id); 
        }

        public void TAdd(MasterBrand t)
        {
            _masterBrandDal.Insert(t);
        }

        public void TDelete(MasterBrand t)
        {
           _masterBrandDal.Delete(t);
        }

        public List<MasterBrand> TGetList()
        {
           return _masterBrandDal.GetList();
        }

        public void TUpdate(MasterBrand t)
        {
           _masterBrandDal.Update(t);
        }
    }
}
