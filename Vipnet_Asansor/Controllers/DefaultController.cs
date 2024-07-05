using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class DefaultController : Controller
    {
        /* Anasayfa Yapısı  */
        public IActionResult Index()
        {
            return View();
        }


        /* Hakkımızda Yapısı  */

        public IActionResult About()
        {
            return View();
        }

        /* Arge Yapısı  */

        public IActionResult Arge()
        {
            return View();
        }

        /* İletişim Yapısı  */

        public IActionResult Contact()
        {
            return View();
        }

        /* Mesaj Kutusu*/
        [HttpGet]
        public PartialViewResult Message()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Message(Message p)
        {
            MessageManager messageManager = new MessageManager(new EfMessageDal());
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()); // Mesaj atıldığı tarih
            p.Status = true; // Mesaj okunma durumu
            messageManager.TAdd(p);
            return PartialView();
        }
    }
}
