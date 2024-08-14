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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetById(int id)
        {
           return _userDal.GetById(id);
        }

        public void TAdd(User t)
        {
           _userDal.Insert(t);  
        }

        public void TDelete(User t)
        {
           _userDal.Delete(t);  
        }

        public List<User> TGetList()
        {
            return _userDal.GetList();
        }

        public void TUpdate(User t)
        {
           _userDal.Update(t);  
        }

        public User Get(Func<User, bool> filter)
        {
            return _userDal.Get(filter); // Buraya ekleyin
        }

    }
}
