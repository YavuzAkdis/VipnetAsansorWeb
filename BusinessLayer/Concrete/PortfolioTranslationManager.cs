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
    public class PortfolioTranslationManager : IPortfolioTranslationService
    {
        IPortfolioTranslationDal _portfolioTranslationDal;

        public PortfolioTranslationManager(IPortfolioTranslationDal portfolioTranslationDal)
        {
            _portfolioTranslationDal = portfolioTranslationDal;
        }

        public PortfolioTranslation GetById(int id)
        {
            return _portfolioTranslationDal.GetById(id);    
        }

        public void TAdd(PortfolioTranslation t)
        {
           _portfolioTranslationDal.Insert(t);
        }

        public void TDelete(PortfolioTranslation t)
        {
            _portfolioTranslationDal.Delete(t);
        }

        public List<PortfolioTranslation> TGetList()
        {
            return _portfolioTranslationDal.GetList();  
        }

        public void TUpdate(PortfolioTranslation t)
        {
          _portfolioTranslationDal.Update(t);
        }
    }
}
