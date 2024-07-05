using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Vipnet_Asansor.ViewComponents.Questions
{
    public class QuestionsList : ViewComponent
    {
        QuestionsManager questionsManager=new QuestionsManager(new EfQuestionsDal());
        public IViewComponentResult Invoke()
        {
            var values = questionsManager.TGetList();
            return View(values);
        }


    }
}
