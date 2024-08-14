using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.Header
{
    public class HeaderList : ViewComponent
    {
        HeaderManager headerManager = new HeaderManager(new EfHeaderDal());
        public IViewComponentResult Invoke(string language)
        {
            var values = headerManager.TGetList().Where(x => x.Language == language).ToList();
            return View(values);
        }


    }
}

