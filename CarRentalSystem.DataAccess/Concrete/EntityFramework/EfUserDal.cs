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
        public void SendMail(string email, string password)
        {
            using (CarRentalContext db = new CarRentalContext())
            {
                db.Database.ExecuteSqlRaw($"exec usp_BilgileriMailGonder '{email}','{password}'");

                
            }

        }
    }
}
