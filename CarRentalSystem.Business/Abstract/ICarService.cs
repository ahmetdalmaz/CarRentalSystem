using CarRentalSystem.Business.Responses;
using CarRentalSystem.Entities.Concrete;
using CarRentalSystem.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Abstract
{
    public interface ICarService
    {
        IResponse Add(Car car);
        IResponse Update(Car car);
        IResponse Delete(Car car);
        IDataResponse<List<Car>> GetCars();
        Car GetCarById(int id);
        Task<List<CarDetailDto>> GetCarDetails();
      
        IDataResponse<int> GetCarCount();

    }
}
