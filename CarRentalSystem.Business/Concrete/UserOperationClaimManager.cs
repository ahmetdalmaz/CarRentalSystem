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
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResponse Add(UserOperationClaim userOperationClaim)
        {
           _userOperationClaimDal.Add(userOperationClaim);
            return Response.Success();
        }

        public IResponse Delete(UserOperationClaim userOperationClaim)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<List<UserOperationClaim>> GetClaimsByUserId(int userId)
        {
            return Response<List<UserOperationClaim>>.Success(_userOperationClaimDal.GetAll(u => u.UserId == userId));
        }

        public IResponse Update(UserOperationClaim userOperationClaim)
        {
            throw new NotImplementedException();
        }
    }
}
