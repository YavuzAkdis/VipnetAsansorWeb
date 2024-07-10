using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class MasterBrandController : Controller
    {
        MasterBrandManager masterBrandManager = new MasterBrandManager(new EfMasterBrandDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "AnaMarka Listesi";

            var values = masterBrandManager.TGetList();
            return View(values);
        }

        // AnaMarka Ekle
        [HttpGet]
        public IActionResult AddMasterBrand()
        {
            ViewBag.d1 = "AnaMarka Ekle";

            return View();
        }
        [HttpPost]
        public IActionResult AddMasterBrand(MasterBrand masterbrand)
        {
            masterBrandManager.TAdd(masterbrand);
            return RedirectToAction("Index");
        }

        // AnaMarka Sil
        public IActionResult DeleteMasterBrand(int id)
        {
            var values = masterBrandManager.GetById(id);
            masterBrandManager.TDelete(values);
            return RedirectToAction("Index");
        }

        // AnaMarka Güncelle
        [HttpGet]
        public IActionResult EditMasterBrand(int id)
        {
            ViewBag.d1 = "AnaMarka Güncelleme";
            var values = masterBrandManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditMasterBrand(MasterBrand masterbrand)
        {
            ViewBag.d1 = "AnaMarka Güncelleme";
            if (ModelState.IsValid)
            {
                masterBrandManager.TUpdate(masterbrand);
                return RedirectToAction("Index");
            }
            return View(masterbrand);
        }
    }
}
