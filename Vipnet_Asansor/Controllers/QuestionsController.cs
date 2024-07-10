using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.Controllers
{
    public class QuestionsController : Controller
    {
        QuestionsManager questionsManager = new QuestionsManager(new EfQuestionsDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "S.S.S Listesi";

            var values = questionsManager.TGetList();
            return View(values);
        }

        // S.S.S Ekle
        [HttpGet]
        public IActionResult AddQuestions()
        {
            ViewBag.d1 = "S.S.S Ekle";

            return View();
        }
        [HttpPost]
        public IActionResult AddQuestions(Questions questions)
        {
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
            ViewBag.d1 = "S.S.S Güncelleme";
            var values = questionsManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditQuestions(Questions questions)
        {
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
