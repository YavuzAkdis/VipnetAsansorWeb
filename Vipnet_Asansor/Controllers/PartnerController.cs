using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class PartnerController : Controller
    {
        PartnerManager partnerManager = new PartnerManager(new EfPartnerDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "Partner Listesi";

            var values = partnerManager.TGetList();
            return View(values);
        }

        // Partner Ekle
        [HttpGet]
        public IActionResult AddPartner()
        {
            ViewBag.d1 = "Partner Ekle";

            return View();
        }
        [HttpPost]
        public IActionResult AddPartner(Partner partner)
        {
            partnerManager.TAdd(partner);
            return RedirectToAction("Index");
        }

        // Partner Sil
        public IActionResult DeletePartner(int id)
        {
            var values = partnerManager.GetById(id);
            partnerManager.TDelete(values);
            return RedirectToAction("Index");
        }

        // Partner Güncelle
        [HttpGet]
        public IActionResult EditPartner(int id)
        {
            ViewBag.d1 = "Partner Güncelleme";
            var values = partnerManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditPartner(Partner partner)
        {
            ViewBag.d1 = "Partner Güncelleme";
            if (ModelState.IsValid)
            {
                partnerManager.TUpdate(partner);
                return RedirectToAction("Index");
            }
            return View(partner);
        }
    }
}

