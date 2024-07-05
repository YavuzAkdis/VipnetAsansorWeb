using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.Partner
{
    public class PartnerList : ViewComponent
    {
        PartnerManager partnerManager = new PartnerManager(new EfPartnerDal());
        public IViewComponentResult Invoke()
        {
            var values = partnerManager.TGetList();
            return View(values);
        }


    }
}
