using CarRentalSystem.DataAccess.Abstract;
using CarRentalSystem.Entities.Concrete;
using CarRentalSystem.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Concrete.EntityFramework
{
    public class EfRoleClaim : EfEntityRepositoryBase<RoleClaim>, IRoleClaimDal
    {
        public List<RoleClaimDto> GetRoleClaims()
        {
            using (CarRentalContext db = new CarRentalContext())
            {
                var result = from claims in db.RoleClaims select new RoleClaimDto { RoleClaimId = claims.RoleClaimId, ClaimName = claims.Name, RoleName = claims.Role.Name };
                return result.ToList();
            }

           
        }
    }
}
