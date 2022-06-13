using CarRentalSystem.Business.Responses;
using CarRentalSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Abstract
{
    public interface ICustomerService
    {
        IResponse Add(Customer customer );
        IResponse Update(Customer customer);
        IResponse Delete(Customer customer);
        IDataResponse<List<Customer>> GetAll();
        IDataResponse<Customer> GetCustomerById(int id);
        IDataResponse<Customer> GetCustomerByIdentityNumber(string identityNumber);
        Task<IDataResponse<List<Customer>>> GetAllAsync();


    }
}
