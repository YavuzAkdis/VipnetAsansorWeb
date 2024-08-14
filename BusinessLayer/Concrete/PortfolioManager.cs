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
    public class PortfolioManager : IPortfolioService
    {
        IPortfolioDal _portfolioDal;

        public PortfolioManager(IPortfolioDal portfolioDal)
        {
            _portfolioDal = portfolioDal;
        }

        public Portfolio GetById(int id)
        {
           return _portfolioDal.GetById(id);    
        }

        public void TAdd(Portfolio t)
        {
           _portfolioDal.Insert(t);
        }

        public void TDelete(Portfolio t)
        {
           _portfolioDal.Delete(t);
        }

        public List<Portfolio> TGetList()
        {
           return _portfolioDal.GetList();
        }

        public List<Portfolio> GetList(string language)
        {
            Expression<Func<Portfolio, bool>> filter = a => a.Language == language;
            return _portfolioDal.GetList(filter);
        }

        public void TUpdate(Portfolio t)
        {
           _portfolioDal.Update(t);
        }
    }
}
