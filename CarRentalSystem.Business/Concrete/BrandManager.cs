using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Responses;
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

        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
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

        public void Update(Brand brand)
        {
           _brandDal.Update(brand);
        }
    }
}
