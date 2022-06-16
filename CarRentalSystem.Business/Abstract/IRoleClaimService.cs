using CarRentalSystem.Business.Responses;
using CarRentalSystem.Entities.Concrete;
using CarRentalSystem.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Abstract
{
    public interface IRoleClaimService
    {
        IResponse Add(List<RoleClaim> roleClaim);
        IResponse Update(RoleClaim roleClaim);
        IResponse Delete(RoleClaim roleClaim);
        IDataResponse<string[]> GetRoleClaimsByRoleId(int roleId);
        IResponse CheckUserRoleClaims(string claim);
        IDataResponse<List<RoleClaimDto>> GetRoleClaims();
        

    }
}
