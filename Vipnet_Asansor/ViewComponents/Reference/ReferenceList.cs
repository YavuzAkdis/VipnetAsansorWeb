using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.Reference
{
    public class ReferenceList:ViewComponent
    {
        ReferenceManager referenceManager = new ReferenceManager(new EfReferenceDal());
        public IViewComponentResult Invoke()
        {
            var values = referenceManager.TGetList();
            return View(values);
        }


    }
}
