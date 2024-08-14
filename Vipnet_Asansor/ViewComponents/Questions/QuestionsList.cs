using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.Questions
{
    public class QuestionsList : ViewComponent
    {
        QuestionsManager questionsManager=new QuestionsManager(new EfQuestionsDal());
        public IViewComponentResult Invoke(string language)
        {
            var values = questionsManager.TGetList().Where(x => x.Language == language).ToList();
            return View(values);
        }

    }
}
