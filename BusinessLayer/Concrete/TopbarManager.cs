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
    public class TopbarManager : ITopbarService
    {
        ITopbarDal _topbarDal;

        public TopbarManager(ITopbarDal topbarDal)
        {
            _topbarDal = topbarDal;
        }

        public Topbar GetById(int id)
        {
            return _topbarDal.GetById(id);  
        }

        public void TAdd(Topbar t)
        {
            _topbarDal.Insert(t);
        }

        public void TDelete(Topbar t)
        {
            _topbarDal.Delete(t);
        }

        public List<Topbar> TGetList()
        {
            return _topbarDal.GetList();    
        }

        public void TUpdate(Topbar t)
        {
           _topbarDal.Update(t);    
        }
    }
}
