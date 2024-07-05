using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.Message
{
    public class MessageList : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());

        [HttpGet]
        public IViewComponentResult Invoke()
        {
            
            return View();
        }

  
    }
}
