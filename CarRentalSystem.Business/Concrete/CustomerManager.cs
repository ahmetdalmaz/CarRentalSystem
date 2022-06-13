using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Constants;
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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResponse Add(Customer customer)
        {
          var validationResult =  ValidationTool.Validate<CustomerValidator>(customer);
            if (validationResult.Count>0)
            {
                return Response.Fail(Messages.RegistrationFailed, validationResult);
            }
            else
            {
                _customerDal.Add(customer);
                return Response.Success();
            }

        }

        public IResponse Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return Response.Success();
        }

        public IDataResponse<List<Customer>> GetAll()
        {
            return Response<List<Customer>>.Success(_customerDal.GetAll(c=>c.State == true));
        }

        public async Task<IDataResponse<List<Customer>>> GetAllAsync()
        {
            var customerList = await _customerDal.GetListAsync();
            return Response<List<Customer>>.Success(customerList);



        }

        public IDataResponse<Customer> GetCustomerById(int id)
        {
            return Response<Customer>.Success(_customerDal.Get(c => c.CustomerId == id));
        }

        public IDataResponse<Customer> GetCustomerByIdentityNumber(string identityNumber)
        {
            return Response<Customer>.Success(_customerDal.Get(c => c.IdentityNumber == identityNumber));
        }

       
        public IResponse Update(Customer customer)
        {
          
            var validationResult = ValidationTool.Validate<CustomerValidator>(customer);
            if (validationResult.Count > 0)
            {
                return Response.Fail(Messages.UpdateFailed, validationResult);
            }
            else
            {
                _customerDal.Update(customer);
                return Response.Success();
            }
            
        }
    }
}
