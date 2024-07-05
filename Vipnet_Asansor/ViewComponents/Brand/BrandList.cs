using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.Brand
{
    public class BrandList : ViewComponent
    {
        BrandManager brandmanager = new BrandManager(new EfBrandDal());
        public IViewComponentResult Invoke()
        {
            var values = brandmanager.TGetList();
            return View(values);
        }


    }
}
