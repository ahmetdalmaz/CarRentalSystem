using CarRentalSystem.Business.Responses;
using CarRentalSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Abstract
{
    public interface IBrandService
    {
        IResponse Add(Brand brand);
        IResponse Update(Brand brand);
        void Delete(Brand brand);
        List<Brand> GetBrands();
        Task<IDataResponse<List<Brand>>> GetAllAsync();


    }
}
