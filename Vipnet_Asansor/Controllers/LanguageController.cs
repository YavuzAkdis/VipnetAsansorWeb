using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class LanguageController : Controller
    {

        public IActionResult SetLanguage(string lang)
        {

            HttpContext.Response.Cookies.Append("App.Constant",CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(lang)), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            return RedirectToAction("Index", "Default");
        }
    }

}
