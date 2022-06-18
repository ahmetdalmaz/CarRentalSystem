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
        IResponse Update(List<RoleClaim> roleClaims);
        IResponse Delete(List<RoleClaim> roleClaims);
        IDataResponse<string[]> GetRoleClaimsByRoleId(int roleId);
        IResponse CheckUserRoleClaims(string claim);
        IDataResponse<List<RoleClaimDto>> GetRoleClaims();
        

    }
}
