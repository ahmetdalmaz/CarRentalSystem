using CarRentalSystem.Business.Responses;
using CarRentalSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IResponse Add(UserOperationClaim userOperationClaim);
        IResponse Update(UserOperationClaim userOperationClaim);
        IResponse Delete(UserOperationClaim userOperationClaim);
        IDataResponse<List<UserOperationClaim>> GetClaimsByUserId(int userId);
        

    }
}
