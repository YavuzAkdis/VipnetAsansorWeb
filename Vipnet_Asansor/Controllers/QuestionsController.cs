using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    [Authorize(Roles = "Admin")] // Sadece Admin rolüne sahip kullanıcılar erişebilir
    public class QuestionsController : Controller
    {
        QuestionsManager questionsManager = new QuestionsManager(new EfQuestionsDal());


        public IActionResult Index(string language = "tr-TR") // Varsayılan dil 'tr-TR'
        {
            ViewBag.d1 = "S.S.S Listesi";

            var values = questionsManager.TGetList().Where(x => x.Language == language).ToList();
            return View(values);
        }

  

        // S.S.S Ekle
        [HttpGet]
        public IActionResult AddQuestions()
        {
            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar

            ViewBag.d1 = "S.S.S Ekle";

            return View();
        }
        [HttpPost]
        public IActionResult AddQuestions(Questions questions, string language)
        {
            questions.Language = language; // Dil bilgisini ata

            questionsManager.TAdd(questions);
            return RedirectToAction("Index");
        }

        // S.S.S Sil
        public IActionResult DeleteQuestions(int id)
        {
            var values = questionsManager.GetById(id);
            questionsManager.TDelete(values);
            return RedirectToAction("Index");
        }

        // S.S.S Güncelle
        [HttpGet]
        public IActionResult EditQuestions(int id)
        {
            ViewBag.CurrentLanguage = Request.Query["language"].ToString(); // Dil bilgisini ViewBag ile aktar

            ViewBag.d1 = "S.S.S Güncelleme";
            var values = questionsManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditQuestions(Questions questions, string language)
        {
            questions.Language = language; // Dil bilgisini ata

            ViewBag.d1 = "S.S.S Güncelleme";
            if (ModelState.IsValid)
            {
                questionsManager.TUpdate(questions);
                return RedirectToAction("Index");
            }
            return View(questions);
        }
    }
}
