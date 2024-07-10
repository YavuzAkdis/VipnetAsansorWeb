using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class ReferenceController : Controller
    {
        ReferenceManager referenceManager = new ReferenceManager(new EfReferenceDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "Reference Listesi";

            var values = referenceManager.TGetList();
            return View(values);
        }

        // Reference Ekle
        [HttpGet]
        public IActionResult AddReference()
        {
            ViewBag.d1 = "Reference Ekle";

            return View();
        }
        [HttpPost]
        public IActionResult AddReference(Reference reference)
        {
            referenceManager.TAdd(reference);
            return RedirectToAction("Index");
        }

        // Reference Sil
        public IActionResult DeleteReference(int id)
        {
            var values = referenceManager.GetById(id);
            referenceManager.TDelete(values);
            return RedirectToAction("Index");
        }

        // Reference Güncelle
        [HttpGet]
        public IActionResult EditReference(int id)
        {
            ViewBag.d1 = "Reference Güncelleme";
            var values = referenceManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditReference(Reference reference)
        {
            ViewBag.d1 = "Reference Güncelleme";
            if (ModelState.IsValid)
            {
                referenceManager.TUpdate(reference);
                return RedirectToAction("Index");
            }
            return View(reference);
        }
    }
}
