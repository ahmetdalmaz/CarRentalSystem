using CarRentalSystem.Business.Responses;
using CarRentalSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Abstract
{
    public interface IModelService
    {
        IResponse Add(Model model);
        IResponse Update(Model model);
        void Delete(Model model);
        List<Model> GetModels();
        Task<List<Model>> GetModelsByBrandId(int brandId);

    }
}
