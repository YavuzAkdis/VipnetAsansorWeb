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

        public PartialViewResult FeaturePartial()
        {
            return PartialView();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult ProductsPartial()
        {
            return PartialView();
        }

        public PartialViewResult PortfolioPartial()
        {
            return PartialView();
        }

        public PartialViewResult QuestionsPartial()
        {
            return PartialView();
        }

        public PartialViewResult MasterBrandPartial()
        {
            return PartialView();
        }

        public PartialViewResult BrandPartial()
        {
            return PartialView();
        }

        /* Hakkımızda Yapısı  */

        public IActionResult About()
        {
            return View();
        }

    }
}
