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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);    
        }

        public void TAdd(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public List<Category> TGetList()
        {
            return _categoryDal.GetList();
        }


        public List<Category> GetList(string language)
        {
            Expression<Func<Category, bool>> filter = a => a.Language == language;
            return _categoryDal.GetList(filter);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
