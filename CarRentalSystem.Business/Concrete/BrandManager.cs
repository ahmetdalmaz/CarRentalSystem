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
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResponse Add(Brand brand)
        {
            var validationResult = ValidationTool.Validate<BrandValidator>(brand);

            if (validationResult.Count > 0)
            {
                return Response.Fail("Marka Eklenemedi", validationResult);
            }

            _brandDal.Add(brand);
            return Response.Success();
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public async Task<IDataResponse<List<Brand>>> GetAllAsync()
        {
            var brandList = await _brandDal.GetListAsync();
            return Response<List<Brand>>.Success(brandList);
        }

        public List<Brand> GetBrands()
        {
            return _brandDal.GetAll();
        }

        public IResponse Update(Brand brand)
        {
            var validationResult = ValidationTool.Validate<BrandValidator>(brand);

            if (validationResult.Count > 0)
            {
                return Response.Fail("Marka Güncellenemedi", validationResult);
            }

            _brandDal.Update(brand);
            return Response.Success();
        }
    }
}
