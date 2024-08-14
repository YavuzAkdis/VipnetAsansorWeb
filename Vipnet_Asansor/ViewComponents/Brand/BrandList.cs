using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.Brand
{
    public class BrandList : ViewComponent
    {
        BrandManager brandmanager = new BrandManager(new EfBrandDal());
        public IViewComponentResult Invoke(string language)
        {
            var values = brandmanager.TGetList().Where(x => x.Language == language).ToList();
            return View(values);
        }


    }
}
