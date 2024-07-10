using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "About Listesi";

            var values = aboutManager.TGetList();
            return View(values);
        }

        // About Ekle
        [HttpGet]
        public IActionResult AddAbout()
        {
            ViewBag.d1 = "About Ekle";

            return View();
        }
        [HttpPost]
        public IActionResult AddAbout(About about)
        {
            aboutManager.TAdd(about);
            return RedirectToAction("Index");
        }

        // About Sil
        public IActionResult DeleteAbout(int id)
        {
            var values = aboutManager.GetById(id);
            aboutManager.TDelete(values);
            return RedirectToAction("Index");
        }

        // About Güncelle
        [HttpGet]
        public IActionResult EditAbout(int id)
        {
            ViewBag.d1 = "About Güncelleme";
            var values = aboutManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditAbout(About about)
        {
            ViewBag.d1 = "About Güncelleme";
            if (ModelState.IsValid)
            {
                aboutManager.TUpdate(about);
                return RedirectToAction("Index");
            }
            return View(about);
        }
    }
}
