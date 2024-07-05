using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryTranslationManager : ICategoryTranslationService
    {
        ICategoryTranslationDal _categoryTranslationDal;

        public CategoryTranslationManager(ICategoryTranslationDal categoryTranslationDal)
        {
            _categoryTranslationDal = categoryTranslationDal;
        }

        public CategoryTranslation GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(CategoryTranslation t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(CategoryTranslation t)
        {
            throw new NotImplementedException();
        }

        public List<CategoryTranslation> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(CategoryTranslation t)
        {
            throw new NotImplementedException();
        }
    }
}
