using CarRentalSystem.DataAccess.Abstract;
using CarRentalSystem.Entities.Concrete;
using CarRentalSystem.Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car>, ICarDal
    {
        public async Task<List<CarDetailDto>> GetCarDetails()
        {
            using (CarRentalContext db  = new CarRentalContext())
            {
                //var carDetails = from c in db.Cars
                //                 join d in db.Segments on c.SegmentId equals d.SegmentId
                //                 join m in db.Models on c.ModelId equals m.ModelId
                //                 select new CarDetailDto
                //                 {
                //                     CarId = c.CarId,
                //                     Color = c.Color,
                //                     FuelType = c.FuelType,
                //                     Kilometre = c.Kilometre,
                //                     ModelName = m.ModelName,
                //                     Plate = c.Plate,
                //                     SegmentName = d.SegmentName,
                //                     State = c.State
                //                 };
                //return carDetails.ToList();
               
                var carDetails= from c in db.Cars where c.State == true select new CarDetailDto { CarId = c.CarId, Color = c.Color,
                    FuelType = c.FuelType,
                    Kilometre = c.Kilometre, 
                    ModelName = c.Model.ModelName,
                    Plate = c.Plate,
                    SegmentName = c.Segment.SegmentName,
                    State = c.State,
                    BrandName = c.Model.Brand.BrandName
                };
                return await carDetails.ToListAsync();

                }
          


        }
    }
}
