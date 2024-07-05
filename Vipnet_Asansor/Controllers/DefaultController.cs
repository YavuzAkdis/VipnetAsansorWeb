using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /* Anasayfa Yapısı  */
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

        /* Anasayfa Yapısı  */
    }
}
