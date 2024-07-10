using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class FeatureController : Controller
    {
       FeatureManager featureManager = new FeatureManager(new EfFeatureDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "Feature Listesi";

            var values = featureManager.TGetList();
            return View(values);
        }

        // Feature Ekle
        [HttpGet]
        public IActionResult AddFeature()
        {
            ViewBag.d1 = "Feature Ekle";

            return View();
        }
        [HttpPost]
        public IActionResult AddFeature(Feature feature)
        {
            featureManager.TAdd(feature);
            return RedirectToAction("Index");
        }

        // Feature Sil
        public IActionResult DeleteFeature(int id)
        {
            var values = featureManager.GetById(id);
            featureManager.TDelete(values);
            return RedirectToAction("Index");
        }

        // Feature Güncelle
        [HttpGet]
        public IActionResult EditFeature(int id)
        {
            ViewBag.d1 = "Feature Güncelleme";
            var values = featureManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditFeature(Feature feature)
        {
            ViewBag.d1 = "Partner Güncelleme";
            if (ModelState.IsValid)
            {
                featureManager.TUpdate(feature);
                return RedirectToAction("Index");
            }
            return View(feature);
        }
    }
}
