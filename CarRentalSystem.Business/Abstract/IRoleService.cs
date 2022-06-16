using CarRentalSystem.Business.Responses;
using CarRentalSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Abstract
{
    public interface IRoleService
    {
        IResponse Add(Role operationClaim);
        IResponse Update(Role operationClaim);
        IResponse Delete(Role operationClaim);
        IDataResponse<List<Role>> GetOperationClaims();

    }
}
