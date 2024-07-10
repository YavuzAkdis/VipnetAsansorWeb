using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.Arge
{
    public class ArgeList : ViewComponent
    {
        ArgeManager argeManager = new ArgeManager(new EfArgeDal());
        public IViewComponentResult Invoke()
        {
            var values = argeManager.TGetList();
            return View(values);
        }


    }
}
