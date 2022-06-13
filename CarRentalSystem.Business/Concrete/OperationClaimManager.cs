using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Responses;
using CarRentalSystem.DataAccess.Abstract;
using CarRentalSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public IResponse Add(OperationClaim operationClaim)
        {
            _operationClaimDal.Add(operationClaim);
            return Response.Success();
        }

        public IResponse Delete(OperationClaim operationClaim)
        {
            _operationClaimDal.Delete(operationClaim);
            return Response.Success();
        }

        public IDataResponse<List<OperationClaim>> GetOperationClaims()
        {
            return Response<List<OperationClaim>>.Success(_operationClaimDal.GetAll());
            
        }

        public IResponse Update(OperationClaim operationClaim)
        {
            _operationClaimDal.Update(operationClaim);
            return Response.Success();
        }
    }
}
