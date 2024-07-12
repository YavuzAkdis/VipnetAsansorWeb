using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.Category
{
    public class CategoryList : ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IViewComponentResult Invoke()
        {
            var values = categoryManager.TGetList();

            return View(values);
        }


    }
}
