using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    [Authorize(Roles = "Admin")] // Sadece Admin rolüne sahip kullanıcılar erişebilir
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());

        public IActionResult Index(string language = "tr-TR") // Varsayılan dil 'tr-TR'
        {
            ViewBag.d1 = "Portfolio Listesi";

            var values = portfolioManager.TGetList().Where(x => x.Language == language).ToList();
            return View(values);
        }

    

        // Portfolio Ekle
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar

            ViewBag.d1 = "Portfolio Ekle";

            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio, string language)
        {
            portfolio.Language = language; // Dil bilgisini ata
            portfolioManager.TAdd(portfolio);
            return RedirectToAction("Index");
        }

        // Portfolio Sil
        public IActionResult DeletePortfolio(int id)
        {
            var values = portfolioManager.GetById(id);
            portfolioManager.TDelete(values);
            return RedirectToAction("Index");
        }

        // Portfolio Güncelle
        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar
            ViewBag.d1 = "Portfolio Güncelleme";
            var values = portfolioManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio, string language)
        {
            portfolio.Language = language; // Dil bilgisini ata

            ViewBag.d1 = "Portfolio Güncelleme";
            if (ModelState.IsValid)
            {
                portfolioManager.TUpdate(portfolio);
                return RedirectToAction("Index");
            }
            return View(portfolio);
        }
    }
}
