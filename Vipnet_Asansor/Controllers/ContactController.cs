using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "İletişim Listesi";

            var values = contactManager.TGetList();
            return View(values);
        }

        // İletişim Ekle
        [HttpGet]
        public IActionResult AddContact()
        {
            ViewBag.d1 = "İletişim Ekle";

            return View();
        }
        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            contactManager.TAdd(contact);
            return RedirectToAction("Index");
        }

        // İletişim Sil
        public IActionResult DeleteContact(int id)
        {
            var values = contactManager.GetById(id);
            contactManager.TDelete(values);
            return RedirectToAction("Index");
        }

        // İletişim Güncelle
        [HttpGet]
        public IActionResult EditContact(int id)
        {
            ViewBag.d1 = "İletişim Güncelleme";
            var values = contactManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditContact(Contact contact)
        {
            ViewBag.d1 = "İletişim Güncelleme";
            if (ModelState.IsValid)
            {
                contactManager.TUpdate(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }
    }
}
