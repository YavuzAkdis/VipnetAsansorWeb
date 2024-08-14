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
    public class GalleryManager : IGalleryService
    {
        IGalleryDal _galleryDal;

        public GalleryManager(IGalleryDal galleryDal)
        {
            _galleryDal = galleryDal;
        }

        public Gallery GetById(int id)
        {
           return _galleryDal.GetById(id);
        }

        public void TAdd(Gallery t)
        {
           _galleryDal.Insert(t);
        }

        public void TDelete(Gallery t)
        {
           _galleryDal.Delete(t);
        }

        public List<Gallery> TGetList()
        {
          return _galleryDal.GetList();   
        }

        public List<Gallery> GetList(string language)
        {
            Expression<Func<Gallery, bool>> filter = a => a.Language == language;
            return _galleryDal.GetList(filter);
        }


        public void TUpdate(Gallery t)
        {
            _galleryDal.Update(t);  
        }
    }
}
