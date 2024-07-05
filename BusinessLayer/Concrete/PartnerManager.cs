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
    public class PartnerManager : IPartnerService
    {
        IPartnerDal _partnerDal;

        public PartnerManager(IPartnerDal partnerDal)
        {
            _partnerDal = partnerDal;
        }

        public Partner GetById(int id)
        {
           return _partnerDal.GetById(id);  
        }

        public void TAdd(Partner t)
        {
            _partnerDal.Insert(t);  
        }

        public void TDelete(Partner t)
        {
            _partnerDal.Delete(t);  
        }

        public List<Partner> TGetList()
        {
           return _partnerDal.GetList();
        }

        public void TUpdate(Partner t)
        {
           _partnerDal.Update(t);
        }
    }
}
