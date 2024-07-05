using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Vipnet_Asansor.Controllers
{
    public class AdminController : Controller
    {
        private readonly Context _context;
        public AdminController(Context context)
        {
            _context = context;
        }

        /* About*/
        public IActionResult About()
        {
            var abouts = _context.Abouts.Include(a => a.AboutTranslations).ToList();
            return View(abouts);
        }

        [HttpGet]
        public IActionResult EditAbout(int id)
        {
            var about = _context.Abouts.Include(a => a.AboutTranslations)
                                       .FirstOrDefault(a => a.AboutID == id);
            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }

        [HttpPost]
        public IActionResult EditAbout(About about)
        {
            if (ModelState.IsValid)
            {
                _context.Abouts.Update(about);
                _context.SaveChanges();
                return RedirectToAction(nameof(About));
            }

            return View(about);
        }

        [HttpGet]
        public IActionResult EditAboutTranslation(int aboutId, string language)
        {
            var translation = _context.AboutTranslations
                                      .FirstOrDefault(t => t.AboutID == aboutId && t.Language == language);
            if (translation == null)
            {
                translation = new AboutTranslation { AboutID = aboutId, Language = language };
            }

            return View(translation);
        }

        [HttpPost]
        public IActionResult EditAboutTranslation(AboutTranslation translation)
        {
            if (ModelState.IsValid)
            {
                if (translation.AboutTranslationID == 0)
                {
                    _context.AboutTranslations.Add(translation);
                }
                else
                {
                    _context.AboutTranslations.Update(translation);
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(About));
            }

            return View(translation);
        }

        /* Arge */
        public IActionResult Arges()
        {
            var Arges = _context.Arges.Include(a => a.ArgeTranslations).ToList();
            return View(Arges);
        }

        [HttpGet]
        public IActionResult EditArge(int id)
        {
            var arge = _context.Arges.Include(a => a.ArgeTranslations)
                                       .FirstOrDefault(a => a.ArgeID == id);
            if (arge == null)
            {
                return NotFound();
            }

            return View(arge);
        }

        [HttpPost]
        public IActionResult EditArge(Arge arge)
        {
            if (ModelState.IsValid)
            {
                _context.Arges.Update(arge);
                _context.SaveChanges();
                return RedirectToAction(nameof(Arges));
            }

            return View(arge);
        }

        [HttpGet]
        public IActionResult EditArgeTranslation(int argeId, string language)
        {
            var translation = _context.ArgeTranslations
                                      .FirstOrDefault(t => t.ArgeID == argeId && t.Language == language);
            if (translation == null)
            {
                translation = new ArgeTranslation { ArgeID = argeId, Language = language };
            }

            return View(translation);
        }

        [HttpPost]
        public IActionResult EditArgeTranslation(ArgeTranslation translation)
        {
            if (ModelState.IsValid)
            {
                if (translation.ArgeTranslationID == 0)
                {
                    _context.ArgeTranslations.Add(translation);
                }
                else
                {
                    _context.ArgeTranslations.Update(translation);
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Arges));
            }

            return View(translation);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
