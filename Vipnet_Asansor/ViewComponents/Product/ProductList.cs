using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.ProductList
{
    public class ProductList : ViewComponent
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        public IViewComponentResult Invoke()
        {
            var values = productManager.TGetList();

            return View(values);
        }


    }
}
