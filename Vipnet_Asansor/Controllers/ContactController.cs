using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    [Authorize(Roles = "Admin")] // Sadece Admin rolüne sahip kullanıcılar erişebilir
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());

        public IActionResult Index(string language = "tr-TR") // Varsayılan dil 'tr-TR'
        {
            ViewBag.d1 = "İletişim Listesi";

            var values = contactManager.TGetList().Where(x => x.Language == language).ToList();
            return View(values);
        }


        // İletişim Ekle
        [HttpGet]
        public IActionResult AddContact()
        {
            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar
            ViewBag.d1 = "İletişim Ekle";

            return View();
        }
        [HttpPost]
        public IActionResult AddContact(Contact contact, string language)
        {
            contact.Language = language; // Dil bilgisini ata
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
            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar
            ViewBag.d1 = "İletişim Güncelleme";
            var values = contactManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditContact(Contact contact, string language)
        {
            contact.Language = language; // Dil bilgisini ata
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
