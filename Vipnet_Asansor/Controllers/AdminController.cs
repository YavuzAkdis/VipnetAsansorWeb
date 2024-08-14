using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Vipnet_Asansor.Controllers
{
    [Authorize] // Tüm AdminController için yetkilendirme zorunlu
    public class AdminController : Controller

    {
        [Authorize(Roles = "Admin")] // Sadece Admin rolüne sahip kullanıcılar erişebilir
        public IActionResult Index()
        {
            return View(); // Bu, /Views/Admin/Index.cshtml dosyasını kullanacak
        }
        public PartialViewResult PartialSideBar() // Admin Sol Menü
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar() // Navbar
        {
            return PartialView();
        }

        public PartialViewResult PartialFooter() // Footer
        {
            return PartialView();
        }

        public PartialViewResult PartialHead() // Head
        {
            return PartialView();
        }

        public PartialViewResult PartialScript() // Script
        {
            return PartialView();
        }

        public PartialViewResult NavigationPartial() // Script
        {
            return PartialView();
        }



      
    }
}
