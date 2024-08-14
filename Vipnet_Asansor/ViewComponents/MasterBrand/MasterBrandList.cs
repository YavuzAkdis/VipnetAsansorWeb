using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.MasterBrand
{
    public class MasterBrandList : ViewComponent
    {
        MasterBrandManager masterBrandManager = new MasterBrandManager(new EfMasterBrandDal());
        public IViewComponentResult Invoke(string language)
        {
            var values = masterBrandManager.TGetList().Where(x => x.Language == language).ToList();
            return View(values);
        }


    }
}
