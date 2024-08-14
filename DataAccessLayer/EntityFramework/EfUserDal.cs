using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfUserDal : GenericRepository<User>, IUserDal
    {
        // Ürünleri Url göre listeleme
        public User Get(Func<User, bool> filter)
        {
            using (var context = new Context())
            {
                return context.Users.FirstOrDefault(filter);
            }
        }
    }
}
