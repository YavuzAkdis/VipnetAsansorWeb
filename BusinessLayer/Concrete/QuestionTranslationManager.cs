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
    public class QuestionTranslationManager : IQuestionTranslationService
    {
        IQuestionTranslationDal _questionTranslationDal;

        public QuestionTranslationManager(IQuestionTranslationDal questionTranslationDal)
        {
            _questionTranslationDal = questionTranslationDal;
        }

        public QuestionTranslation GetById(int id)
        {
           return _questionTranslationDal.GetById(id);  
        }

        public void TAdd(QuestionTranslation t)
        {
            _questionTranslationDal.Insert(t);
        }

        public void TDelete(QuestionTranslation t)
        {
           _questionTranslationDal.Delete(t);
        }

        public List<QuestionTranslation> TGetList()
        {
            return _questionTranslationDal.GetList();
        }

        public void TUpdate(QuestionTranslation t)
        {
           _questionTranslationDal.Update(t);
        }
    }
}
