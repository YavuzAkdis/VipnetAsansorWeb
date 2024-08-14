using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Vipnet_Asansor.Models;

namespace Vipnet_Asansor.Controllers
{
    //[Authorize(Roles = "Admin")] // Sadece Admin rolüne sahip kullanýcýlar eriþebilir
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private readonly Context _context;

        //public Homecontroller(Context context)
        //{
        //    _context = context;
        //}

        ///* About */ 
        //public IActionResult About()
        //{
        //    var culture = HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
        //    var about = _context.Abouts
        //        .Include(a => a.AboutTranslations)
        //        .Select(a => new
        //        {
        //            a.AboutID,
        //            a.ImageUrl,
        //            Translation = a.AboutTranslations.FirstOrDefault(t => t.Language == culture)
        //        })
        //        .FirstOrDefault();

        //    return View(about);
        //}

        ///* Arge */

        //public IActionResult Arge()
        //{
        //    var culture = HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
        //    var arge = _context.Arges
        //        .Include(a => a.ArgeTranslations)
        //        .Select(a => new
        //        {
        //            a.ArgeID,
        //            a.ImageUrl,
        //            Translation = a.ArgeTranslations.FirstOrDefault(t => t.Language == culture)
        //        })
        //        .FirstOrDefault();

        //    return View(arge);
        //}

        ///*------*/

        //private readonly ILogger<HomeController> _logger;


        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
