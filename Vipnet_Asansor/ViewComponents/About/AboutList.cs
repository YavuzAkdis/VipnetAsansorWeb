using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.About
{
    public class AboutList : ViewComponent
    {
        AboutManager aboutmanager = new AboutManager(new EfAboutDal());
        public IViewComponentResult Invoke()
        {
            var values = aboutmanager.TGetList();
            return View(values);
        }


    }
}
