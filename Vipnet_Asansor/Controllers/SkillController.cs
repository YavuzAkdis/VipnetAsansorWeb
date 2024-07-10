using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class SkillController : Controller
    {

        SkillManager skillManager = new SkillManager(new EfSkillDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "Yetenek Listesi";
            //ViewBag.d2 = "Yetenekler";
            //ViewBag.d3 = "Yetenek Listesi";
            var values = skillManager.TGetList();
            return View(values);
        }

        // Yetenek Ekle
        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.d1 = "Yetenek Ekle";
          
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);
            return RedirectToAction("Index");
        }

        // Yetenek Sil
        public IActionResult DeleteSkill(int id)
        {
            var values = skillManager.GetById(id);
            skillManager.TDelete(values);
            return RedirectToAction("Index");
        }

        // Yetenek Güncelle
        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            ViewBag.d1 = "Yetenek Güncelleme";
            var values = skillManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            ViewBag.d1 = "Yetenek Güncelleme";
            if (ModelState.IsValid)
            {
                skillManager.TUpdate(skill);
                return RedirectToAction("Index");
            }
            return View(skill);
        }
    }
}


