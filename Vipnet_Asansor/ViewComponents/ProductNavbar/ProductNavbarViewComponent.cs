using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.ProductNavbar
{
    public class ProductNavbarViewComponent : ViewComponent
    {
        private readonly ProductManager _productManager;
       
        public ProductNavbarViewComponent(IHttpContextAccessor httpContextAccessor)
        {
            _productManager = new ProductManager(new EfProductDal());
          
        }

        public IViewComponentResult Invoke(string language)
        {
        
            var products = _productManager.GetProductsByLanguage(language);
            return View(products);
        }
    }
}
