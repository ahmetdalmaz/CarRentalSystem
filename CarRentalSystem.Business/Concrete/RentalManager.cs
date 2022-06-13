using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Responses;
using CarRentalSystem.Business.Utilities;
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
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        private List<Rental> _card;
     

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
            _card = new List<Rental>();
           
        }

        public IResponse Add(Rental rental)
        {
            rental.State = CheckDate(rental.RentalDate);
            _rentalDal.Add(rental);
            return Response.Success();
        }
        private string CheckDate(DateTime rentalDate) 
        {
            if (rentalDate > DateTime.Now)
            {
                return "r";
            }
            return "k";
           
        }

        public IResponse Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return Response.Success();
        }

        public IDataResponse<List<Rental>> GetAll()
        {
            return Response<List<Rental>>.Success(_rentalDal.GetAll());
        }
        
        public async Task<IDataResponse<List<AvailableCarsDto>>> GetAvailableCars(DateTime? rentalDate, DateTime? returnDate, string color, string fuelType, string plate, string modelName, string segmentName)
        {
           
           var result =  _rentalDal.GetAvailableCars(rentalDate,returnDate,color,fuelType,plate,modelName,segmentName);
            return Response<List<AvailableCarsDto>>.Success(await result);
           
        }

        public void AddToCard(Rental rental) 
        {
            _card.Add(rental);
        }

       

        

        public IDataResponse<Rental> GetById(int id)
        {
            return Response<Rental>.Success(_rentalDal.Get(rental => rental.RentalId == id));
            
        }

        public IDataResponse<int> GetRentalState(string state)
        {
          var count =  _rentalDal.GetAll(r=>r.State == state).Count;
          return Response<int>.Success(count);
        }

        public IResponse Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return Response.Success();
        }

        public IResponse Add(List<Rental> rentals)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<List<RentedCarsDto>> GetRentedCars()
        {
            return Response<List<RentedCarsDto>>.Success(_rentalDal.GetRentedCars());
        }

        public IDataResponse<List<Rental>> GetAllByDate(int month)
        {
           return Response<List<Rental>>.Success(_rentalDal.GetAll(r=>r.DateProcessed.Month == month && r.State != "i"));
        }

        public IDataResponse<List<Rental>> GetAllByState()
        {
            return Response<List<Rental>>.Success(_rentalDal.GetAll(r => r.State == "k" || r.State == "r" || r.State == "t"));
        }
    }
}
