using CarRentalSystem.Business.Responses;
using CarRentalSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Abstract
{
    public interface IOperationClaimService
    {
        IResponse Add(OperationClaim operationClaim);
        IResponse Update(OperationClaim operationClaim);
        IResponse Delete(OperationClaim operationClaim);
        IDataResponse<List<OperationClaim>> GetOperationClaims();

    }
}
