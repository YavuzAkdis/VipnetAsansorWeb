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
    public class ArgeManager : IArgeService
    {
        IArgeDal _argeDal;

        public ArgeManager(IArgeDal argeDal)
        {
            _argeDal = argeDal;
        }

        public Arge GetById(int id)
        {
           return _argeDal.GetById(id);
        }

        public void TAdd(Arge t)
        {
            _argeDal.Insert(t);    
        }

        public void TDelete(Arge t)
        {
           _argeDal.Delete(t);
        }

        public List<Arge> TGetList()
        {
            return _argeDal.GetList();
        }

        public void TUpdate(Arge t)
        {
            _argeDal.Update(t);
        }
    }
}
