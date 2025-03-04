﻿using BusinessLayer.Abstract;
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
    public class FeatureManager : IFeatureService
    {
        IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public Feature GetById(int id)
        {
           return _featureDal.GetById(id);  
        }

        public void TAdd(Feature t)
        {
            _featureDal.Insert(t);
        }

        public void TDelete(Feature t)
        {
           _featureDal.Delete(t);   
        }

        public List<Feature> TGetList()
        {
            return _featureDal.GetList();   
        }
        public List<Feature> GetList(string language)
        {
            Expression<Func<Feature, bool>> filter = a => a.Language == language;
            return _featureDal.GetList(filter);
        }



        public void TUpdate(Feature t)
        {
           _featureDal.Update(t);
        }
    }
}
