using CarRentalSystem.DataAccess.Abstract;
using CarRentalSystem.Entities.Concrete;
using CarRentalSystem.Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User>, IUserDal
    {
        public List<UserInfoDto> GetUsers()
        {
            using (CarRentalContext db = new CarRentalContext())
            {
                var result = from user in db.Users select new UserInfoDto 
                { Address = user.Address, Email = user.Email, Name = user.Name, PhoneNumber = user.PhoneNumber, RoleName = user.Role.Name, Surname = user.Surname, UserId = user.UserId, IdentityNumber = user.IdentityNumber };
                return result.ToList();

            }
           
        }
    }
}
