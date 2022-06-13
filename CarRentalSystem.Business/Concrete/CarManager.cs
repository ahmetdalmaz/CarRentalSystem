using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Constants;
using CarRentalSystem.Business.Responses;
using CarRentalSystem.Business.Utilities;
using CarRentalSystem.Business.ValidationRules;
using CarRentalSystem.DataAccess.Abstract;
using CarRentalSystem.Entities.Concrete;
using CarRentalSystem.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResponse Add(Car car)
        {
            var validationResult = ValidationTool.Validate<CarValidator>(car);

            if (validationResult.Count > 0)
            {
                return Response.Fail("Araç Eklenemedi", validationResult);
            }
            else
            {
                _carDal.Add(car);
                return Response.Success(Messages.CarAdded);
            }

            

        }

        public IResponse Delete(Car car)
        {
            _carDal.Delete(car);
            return Response.Success();
        }

        public Car GetCarById(int id)
        {
           return _carDal.Get(c => c.CarId == id);
        }

        
        public IDataResponse<int> GetCarCount()
        {
            return Response<int>.Success(_carDal.GetAll(c=>c.State == true).Count);
        }

        public async Task<List<CarDetailDto>> GetCarDetails()
        {
            return await _carDal.GetCarDetails();
        }

        public IDataResponse<List<Car>> GetCars()
        {
            return Response<List<Car>>.Success(_carDal.GetAll());
        }

        public IResponse Update(Car car)
        {
            var validationResult = ValidationTool.Validate<CarValidator>(car);

            if (validationResult.Count > 0)
            {
                return Response.Fail("Araç Güncellenemedi", validationResult);
            }
            else
            {
                _carDal.Update(car);
                return Response.Success("Araç Güncellendi");

            }


            
        }

       
    }
}
