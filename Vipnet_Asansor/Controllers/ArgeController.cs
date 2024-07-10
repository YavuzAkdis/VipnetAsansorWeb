using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class ArgeController : Controller
    {
        ArgeManager argeManager = new ArgeManager(new EfArgeDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "Arge Sayfası";

            var values = argeManager.TGetList();
            return View(values);
        }

        // Arge Ekle
        [HttpGet]
        public IActionResult AddArge()
        {
            ViewBag.d1 = "Arge Sayfası Ekle";

            return View();
        }
        [HttpPost]
        public IActionResult AddArge(Arge arge)
        {
            argeManager.TAdd(arge);
            return RedirectToAction("Index");
        }

        // Arge Sil
        public IActionResult DeleteArge(int id)
        {
            var values = argeManager.GetById(id);
            argeManager.TDelete(values);
            return RedirectToAction("Index");
        }

        // Arge Güncelle
        [HttpGet]
        public IActionResult EditArge(int id)
        {
            ViewBag.d1 = "Arge Sayfası Güncelleme";
            var values = argeManager.GetById(id);
            return View(values);
        }
  
        [HttpPost]
        public IActionResult EditArge(Arge arge)
        {
            ViewBag.d1 = "Arge Sayfası Güncelleme";
           argeManager.TUpdate(arge);
            return RedirectToAction("Index");
        }
    }
}
