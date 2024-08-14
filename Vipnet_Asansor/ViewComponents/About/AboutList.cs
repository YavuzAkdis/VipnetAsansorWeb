using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.About
{
    public class AboutList : ViewComponent
    {
        AboutManager aboutmanager = new AboutManager(new EfAboutDal());
        public IViewComponentResult Invoke(string language)
        {
            var values = aboutmanager.TGetList().Where(x => x.Language == language).ToList();
            return View(values);
        }


    }
}
