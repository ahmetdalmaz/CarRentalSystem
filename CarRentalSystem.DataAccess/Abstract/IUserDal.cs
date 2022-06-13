using CarRentalSystem.Entities.Concrete;
using CarRentalSystem.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        void SendMail(string email, string password);
    }
}
