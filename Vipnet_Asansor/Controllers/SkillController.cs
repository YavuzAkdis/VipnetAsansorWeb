using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    [Authorize(Roles = "Admin")] // Sadece Admin rolüne sahip kullanıcılar erişebilir
    public class SkillController : Controller
    {

        SkillManager skillManager = new SkillManager(new EfSkillDal());

        public IActionResult Index(string language = "tr-TR") // Varsayılan dil 'tr-TR'
        {
            ViewBag.d1 = "Yetenek Listesi";

            var values = skillManager.TGetList().Where(x => x.Language == language).ToList();
            return View(values);
        }
          

        // Yetenek Ekle
        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar

            ViewBag.d1 = "Yetenek Ekle";
          
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill, string language)
        {
            skill.Language = language; // Dil bilgisini ata
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
            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar

            ViewBag.d1 = "Yetenek Güncelleme";
            var values = skillManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditSkill(Skill skill, string language)
        {
            skill.Language = language; // Dil bilgisini ata

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


