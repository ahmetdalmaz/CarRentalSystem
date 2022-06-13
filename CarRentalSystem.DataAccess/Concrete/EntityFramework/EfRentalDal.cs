using CarRentalSystem.DataAccess.Abstract;
using CarRentalSystem.Entities.Concrete;
using CarRentalSystem.Entities.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental>, IRentalDal
    {
        public async Task<List<AvailableCarsDto>> GetAvailableCars(DateTime? rentalDate, DateTime? returnDate, string color, string fuelType, string plate, string modelName, string segmentName)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                
                var result = context.Set<AvailableCarsDto>().FromSqlRaw($"exec uspAvailableCars '{rentalDate.Value.ToString("MM/dd/yyyy HH:mm")}','{returnDate.Value.ToString("MM/dd/yyyy HH:mm")}','{color}','{fuelType}','{plate}','{modelName}','{segmentName}'").ToListAsync();
                return await result;

                
            }
            
        }
       

        public List<RentedCarsDto> GetRentedCars()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from rental in context.Rentals where rental.State == "k" || rental.State == "r" select new RentedCarsDto 
                { RentalId = rental.RentalId, CarBrand = rental.Car.Model.Brand.BrandName, CarColor = rental.Car.Color, CarModel = rental.Car.Model.ModelName, CustomerIdentityNumber = rental.Customer.IdentityNumber, CustomerName = rental.Customer.Name, RentalDate = rental.RentalDate, ReturnDate = rental.ReturnDate, RentalState = rental.State };
                return result.ToList();
            }
           
        }
    }
}
