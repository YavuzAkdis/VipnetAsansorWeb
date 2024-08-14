using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.Contact
{
    public class ContactList : ViewComponent
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        public IViewComponentResult Invoke(string language)
        {
            var values = contactManager.TGetList().Where(x => x.Language == language).ToList();
            return View(values);
        }



    }
}
