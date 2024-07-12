using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.ProductNavbar
{
    public class ProductNavbarViewComponent : ViewComponent
    {
        private readonly ProductManager _productManager;

        public ProductNavbarViewComponent()
        {
            _productManager = new ProductManager(new EfProductDal());
        }

        public IViewComponentResult Invoke()
        {
            var products = _productManager.TGetList();
            return View(products);
        }
    }
}
