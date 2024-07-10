using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class TopbarController : Controller
    {
        TopbarManager topbarManager = new TopbarManager(new EfTopbarDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "Topbar Listesi";

            var values = topbarManager.TGetList();
            return View(values);
        }

        // Topbar Ekle
        [HttpGet]
        public IActionResult AddTopbar()
        {
            ViewBag.d1 = "Topbar Ekle";

            return View();
        }
        [HttpPost]
        public IActionResult AddTopbar(Topbar topbar)
        {
            topbarManager.TAdd(topbar);
            return RedirectToAction("Index");
        }

        // Topbar Sil
        public IActionResult DeleteTopbar(int id)
        {
            var values = topbarManager.GetById(id);
            topbarManager.TDelete(values);
            return RedirectToAction("Index");
        }

        // Topbar Güncelle
        [HttpGet]
        public IActionResult EditTopbar(int id)
        {
            ViewBag.d1 = "Topbar Güncelleme";
            var values = topbarManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditTopbar(Topbar topbar)
        {
            ViewBag.d1 = "Topbar Güncelleme";
            if (ModelState.IsValid)
            {
                topbarManager.TUpdate(topbar);
                return RedirectToAction("Index");
            }
            return View(topbar);
        }
    }
}
