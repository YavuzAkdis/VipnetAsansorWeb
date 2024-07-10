using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;

namespace Vipnet_Asansor.Controllers
{
    public class BrandController : Controller
    {
        BrandManager brandManager = new BrandManager(new EfBrandDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "Markalarımız Listesi";

            var values = brandManager.TGetList();
            return View(values);
        }

        // Marka Ekle
        [HttpGet]
        public IActionResult AddBrand()
        {
            ViewBag.d1 = "Markalarımız Ekle";

            return View();
        }
        [HttpPost]
        public IActionResult AddBrand(Brand brand)
        {
            brandManager.TAdd(brand);
            return RedirectToAction("Index");
        }

        // Marka Sil
        public IActionResult DeleteBrand(int id)
        {
            var values = brandManager.GetById(id);
            brandManager.TDelete(values);
            return RedirectToAction("Index");
        }

        // Marka Güncelle
        [HttpGet]
        public IActionResult EditBrand(int id)
        {
            ViewBag.d1 = "Markalarımız Güncelleme";
            var values = brandManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditBrand(Brand brand)
        {
            ViewBag.d1 = "Markalarımız Güncelleme";
            if (ModelState.IsValid)
            {
                brandManager.TUpdate(brand);
                return RedirectToAction("Index");
            }
            return View(brand);
        }
    }
}
