using CarRentalSystem.Entities.Concrete;
using CarRentalSystem.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
      Task<List<AvailableCarsDto>> GetAvailableCars(DateTime? rentalDate, DateTime? returnDate, string color, string fuelType, string plate, string modelName, string segmentName);

        List<RentedCarsDto> GetRentedCars();
    }
}
