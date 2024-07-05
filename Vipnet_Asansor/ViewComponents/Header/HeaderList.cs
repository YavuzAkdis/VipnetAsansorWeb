using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.Header
{
    public class HeaderList : ViewComponent
    {
        HeaderManager headerManager = new HeaderManager(new EfHeaderDal());
        public IViewComponentResult Invoke()
        {
            var values = headerManager.TGetList();
            return View(values);
        }


    }
}

