using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.Topbar
{
    public class TopbarList : ViewComponent
    {
        TopbarManager topbarManager = new TopbarManager(new EfTopbarDal());
        public IViewComponentResult Invoke()
        {
            var values = topbarManager.TGetList();
            return View(values);
        }


    }
}
