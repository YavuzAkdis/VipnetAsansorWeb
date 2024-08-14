using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.ProductList
{
    public class ProductList : ViewComponent
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        public IViewComponentResult Invoke(string language)
        {
            var values = productManager.TGetList().Where(x => x.Language == language).ToList();
            return View(values);
        }

    }
}
