using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Responses;
using CarRentalSystem.Business.Utilities;
using CarRentalSystem.Business.ValidationRules;
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

        public IResponse Add(Model model)
        {
            var validationResult = ValidationTool.Validate<ModelValidator>(model);

            if (validationResult.Count > 0)
            {
                return Response.Fail("Model Eklenemedi", validationResult);
            }
            _modelDal.Add(model);
            return Response.Success();
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

        public IResponse Update(Model model)
        {
            var validationResult = ValidationTool.Validate<ModelValidator>(model);

            if (validationResult.Count > 0)
            {
                return Response.Fail("Model Güncellenemedi", validationResult);
            }
            _modelDal.Update(model);
            return Response.Success();
        }
    }
}
