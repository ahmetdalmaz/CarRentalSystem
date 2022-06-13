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
    public interface IRentalService
    {
        IResponse Add(List<Rental> rentals);
        IResponse Delete(Rental rental);
        IResponse Update(Rental rental);

        IDataResponse<List<Rental>> GetAll();
        IDataResponse<Rental> GetById(int id);

       Task< IDataResponse<List<AvailableCarsDto>>> GetAvailableCars(DateTime? rentalDate, DateTime? returnDate, string color, string fuelType, string plate, string modelName, string segmentName);

        IDataResponse<int> GetRentalState(string state);

        IDataResponse<List<RentedCarsDto>> GetRentedCars();
        IDataResponse<List<Rental>> GetAllByDate(int month);
        IDataResponse<List<Rental>> GetAllByState();
        



    }
}
