using CarRentalSystem.Business.Abstract;
using CarRentalSystem.DataAccess.Abstract;
using CarRentalSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Concrete
{
    public class ModelManager : IModelService
    {
        private readonly IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public void Add(Model model)
        {
            _modelDal.Add(model);
        }

        public void Delete(Model model)
        {
            _modelDal.Delete(model);
        }

        public List<Model> GetModels()
        {
           return _modelDal.GetAll();
        }

        public async Task<List<Model>> GetModelsByBrandId(int brandId)
        {
            return await _modelDal.GetListAsync(m=>m.BrandId == brandId);
        }

        public void Update(Model model)
        {
            _modelDal.Update(model);
        }
    }
}
