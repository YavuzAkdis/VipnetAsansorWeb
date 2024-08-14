using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public Skill GetById(int id)
        {
            return _skillDal.GetById(id);   
        }

        public void TAdd(Skill t)
        {
            _skillDal.Insert(t);
        }

        public void TDelete(Skill t)
        {
            _skillDal.Delete(t);
        }

        public List<Skill> TGetList()
        {
            return _skillDal.GetList(); 
        }

        public List<Skill> GetList(string language)
        {
            Expression<Func<Skill, bool>> filter = a => a.Language == language;
            return _skillDal.GetList(filter);
        }

        public void TUpdate(Skill t)
        {
           _skillDal.Update(t); 
        }
    }
}
