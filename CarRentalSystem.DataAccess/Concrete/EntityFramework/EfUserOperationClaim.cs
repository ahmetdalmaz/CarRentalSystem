using CarRentalSystem.DataAccess.Abstract;
using CarRentalSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaim:EfEntityRepositoryBase<UserOperationClaim>,IUserOperationClaimDal
    {

    }
}
