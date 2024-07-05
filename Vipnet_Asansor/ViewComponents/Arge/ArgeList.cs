using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.Arge
{
    public class ArgeList : ViewComponent
    {
        _ArgeManager argeManager = new _ArgeManager(new EfArgeDal());
        public IViewComponentResult Invoke()
        {
            var values = argeManager.TGetList();
            return View(values);
        }


    }
}
