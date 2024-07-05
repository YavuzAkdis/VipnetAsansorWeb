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
    public class SkillTranslationManager : ISkillTranslationService
    {
        ISkillTranslationDal _skillTranslationDal;

        public SkillTranslationManager(ISkillTranslationDal skillTranslationDal)
        {
            _skillTranslationDal = skillTranslationDal;
        }

        public SkillTranslation GetById(int id)
        {
            return _skillTranslationDal.GetById(id);    
        }

        public void TAdd(SkillTranslation t)
        {
            _skillTranslationDal.Insert(t);
        }

        public void TDelete(SkillTranslation t)
        {
           _skillTranslationDal.Delete(t);
        }

        public List<SkillTranslation> TGetList()
        {
          return _skillTranslationDal.GetList();
        }

        public void TUpdate(SkillTranslation t)
        {
           _skillTranslationDal.Update(t);
        }
    }
}
