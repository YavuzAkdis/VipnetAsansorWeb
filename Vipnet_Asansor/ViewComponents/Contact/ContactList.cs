using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.Contact
{
    public class ContactList : ViewComponent
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        public IViewComponentResult Invoke()
        {
            var values = contactManager.TGetList();
            return View(values);
        }


    }
}
