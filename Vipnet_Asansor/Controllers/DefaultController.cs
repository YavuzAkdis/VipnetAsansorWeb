using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using BusinessLayer.Resource;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using BusinessLayer.Abstract;
using System.Security.Policy;
using Vipnet_Asansor.Models; // ViewModel'in bulunduğu namespace
namespace Vipnet_Asansor.Controllers
{
    [AllowAnonymous] // Erişim kısıtlaması yok
    public class DefaultController : Controller
    {
        public IStringLocalizer<StringResource> StringLocalizer { get; }
        private readonly IProductService _productService; // Ürün servisi için bağımlılık

        public DefaultController(IStringLocalizer<BusinessLayer.Resource.StringResource> stringLocalizer, IProductService productService)
        {
            StringLocalizer = stringLocalizer;
            _productService = productService; // Ürün servisi bağımlılığını sağlıyoruz
        }

        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        // Anasayfa
        public IActionResult Index()
        {
            ViewBag.Language = Thread.CurrentThread.CurrentCulture.Name;
            return View();
        }

        // Hakkımızda
        [Route("about")]
        [Route("hakkimizda")]
        public IActionResult About()
        {
            ViewBag.Language = Thread.CurrentThread.CurrentCulture.Name;
            return View();
        }

        // Arge
        [Route("ar-ge")]
        public IActionResult ArGe()
        {
            ViewBag.Language = Thread.CurrentThread.CurrentCulture.Name;
            return View();
        }

        // Galeri
        [Route("gallery")]
        [Route("galeri")]
        public IActionResult Gallery()
        {
            ViewBag.Language = Thread.CurrentThread.CurrentCulture.Name;
            return View();
        }

        // İletişim
        [Route("contact")]
        [Route("iletisim")]
        public IActionResult Contact()
        {
            ViewBag.Language = Thread.CurrentThread.CurrentCulture.Name;
            return View();
        }

        // Mesaj Kutusu
        [HttpGet]
        public PartialViewResult Message()
        {
            return PartialView("Views/Default/Message.cshtml");
        }

        [HttpPost]
        public PartialViewResult Message(Message p)
        {
            MessageManager messageManager = new MessageManager(new EfMessageDal());
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()); // Mesaj atıldığı tarih
            p.Status = true; // Mesaj okunma durumu
            messageManager.TAdd(p);
            return PartialView("Views/Default/Message.cshtml");
        }

        // Ürün Detayları
        [Route("{url}")]
        public IActionResult ProductDetails(string url)
        {
            ViewBag.Language = Thread.CurrentThread.CurrentCulture.Name;

            if (string.IsNullOrEmpty(url))
            {
                return NotFound();
            }

            var product = _productService.GetByUrl(url);
            if (product == null)
            {
                return NotFound();
            }

            // Mevcut dil bilgisiyle uyumlu diğer ürünleri al
            var otherProducts = _productService.GetAllProducts()
                .Where(p => p.ProductId != product.ProductId && p.Language == ViewBag.Language)
                .ToList();

            var model = new ProductDetailsViewModel
            {
                CurrentProduct = product,
                OtherProducts = otherProducts
            };

            return View(model);
        }



    }

}
