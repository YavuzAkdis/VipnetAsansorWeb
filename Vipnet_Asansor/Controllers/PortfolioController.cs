using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "Portfolio Listesi";

            var values = portfolioManager.TGetList();
            return View(values);
        }

        // Portfolio Ekle
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            ViewBag.d1 = "Portfolio Ekle";

            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
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
            ViewBag.d1 = "Portfolio Güncelleme";
            var values = portfolioManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
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
