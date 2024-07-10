using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class SocialMediaController : Controller
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "SocialMedia Listesi";

            var values = socialMediaManager.TGetList();
            return View(values);
        }

        // SocialMedia Ekle
        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            ViewBag.d1 = "SocialMedia Ekle";

            return View();
        }
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            socialMediaManager.TAdd(socialMedia);
            return RedirectToAction("Index");
        }

        // SocialMedia Sil
        public IActionResult DeleteSocialMedia(int id)
        {
            var values = socialMediaManager.GetById(id);
            socialMediaManager.TDelete(values);
            return RedirectToAction("Index");
        }

        // SocialMedia Güncelle
        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            ViewBag.d1 = "SocialMedia Güncelleme";
            var values = socialMediaManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia socialMedia)
        {
            ViewBag.d1 = "SocialMedia Güncelleme";
            if (ModelState.IsValid)
            {
                socialMediaManager.TUpdate(socialMedia);
                return RedirectToAction("Index");
            }
            return View(socialMedia);
        }
    }
}
