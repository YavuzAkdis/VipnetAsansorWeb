using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class QuestionsManager : IQuestionsService
    {
        IQuestionsDal _questionsDal;

        public QuestionsManager(IQuestionsDal questionsDal)
        {
            _questionsDal = questionsDal;
        }

        public Questions GetById(int id)
        {
           return _questionsDal.GetById(id);
        }

        public void TAdd(Questions t)
        {
            _questionsDal.Insert(t);
        }

        public void TDelete(Questions t)
        {
            _questionsDal.Delete(t);    
        }

        public List<Questions> TGetList()
        {
           return _questionsDal.GetList();
        }

        public void TUpdate(Questions t)
        {
            _questionsDal.Update(t);
        }
    }
}
