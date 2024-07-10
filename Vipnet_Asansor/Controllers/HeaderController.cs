using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class HeaderController : Controller
    {
       HeaderManager headerManager = new HeaderManager(new EfHeaderDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "Header Listesi";

            var values = headerManager.TGetList();
            return View(values);
        }

        // Header Ekle
        [HttpGet]
        public IActionResult AddHeader()
        {
            ViewBag.d1 = "Header Ekle";

            return View();
        }
        [HttpPost]
        public IActionResult AddHeader(Header header)
        {
            headerManager.TAdd(header);
            return RedirectToAction("Index");
        }

        // Header Sil
        public IActionResult DeleteHeader(int id)
        {
            var values = headerManager.GetById(id);
            headerManager.TDelete(values);
            return RedirectToAction("Index");
        }

        // Header Güncelle
        [HttpGet]
        public IActionResult EditHeader(int id)
        {
            ViewBag.d1 = "Header Güncelleme";
            var values = headerManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditHeader(Header header)
        {
            ViewBag.d1 = "Header Güncelleme";
            if (ModelState.IsValid)
            {
                headerManager.TUpdate(header);
                return RedirectToAction("Index");
            }

            // ModelState hatalarını loglama
            foreach (var modelState in ViewData.ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    Console.WriteLine(error.ErrorMessage); // veya kullanmakta olduğunuz loglama kütüphanesine loglayın
                }
            }

            return View(header);
        }

    }
}
