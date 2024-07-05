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
    public class FeatureTranslationManager : IFeatureTranslationService
    {
        IFeatureTranslationDal _featureTranslationDal;

        public FeatureTranslationManager(IFeatureTranslationDal featureTranslationDal)
        {
            _featureTranslationDal = featureTranslationDal;
        }

        public FeatureTranslation GetById(int id)
        {
            return _featureTranslationDal.GetById(id);  
        }

        public void TAdd(FeatureTranslation t)
        {
            _featureTranslationDal.Insert(t);
        }

        public void TDelete(FeatureTranslation t)
        {
            _featureTranslationDal.Delete(t);
        }

        public List<FeatureTranslation> TGetList()
        {
            return _featureTranslationDal.GetList();
        }

        public void TUpdate(FeatureTranslation t)
        {
            _featureTranslationDal.Update(t);
        }
    }
}
