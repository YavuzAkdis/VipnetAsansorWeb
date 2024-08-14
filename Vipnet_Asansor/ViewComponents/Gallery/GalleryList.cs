using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.Gallery
{
    public class GalleryList : ViewComponent
    {
        GalleryManager galleryManager = new GalleryManager(new EfGalleryDal());
        public IViewComponentResult Invoke(string language)
        {
            var values = galleryManager.TGetList().Where(x => x.Language == language).ToList();
            return View(values);
        }
    }
}
