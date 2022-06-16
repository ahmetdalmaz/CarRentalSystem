using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Constants;
using CarRentalSystem.Business.Responses;
using CarRentalSystem.Business.Utilities;
using CarRentalSystem.DataAccess.Abstract;
using CarRentalSystem.Entities.Concrete;
using CarRentalSystem.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Concrete
{
    public class RoleClaimManager : IRoleClaimService
    {
        private readonly IRoleClaimDal _roleClaimDal;

        public RoleClaimManager(IRoleClaimDal roleClaimDal)
        {
            _roleClaimDal = roleClaimDal;
        }

        public IResponse Add(List<RoleClaim> roleClaims)
        {
            foreach (var item in roleClaims)
            {
                _roleClaimDal.Add(item);

            }
            return Response.Success();
        }

        public IResponse CheckUserRoleClaims(string claim)
        {
            if (LoginCache.RoleClaims.Contains(claim))
            {
                return Response.Success();

            }
            return Response.Fail(Messages.AuthorizationFailed);
        }

        public IResponse Delete(RoleClaim roleClaim)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<List<RoleClaimDto>> GetRoleClaims()
        {
            return Response<List<RoleClaimDto>>.Success(_roleClaimDal.GetRoleClaims());
        }

        public IDataResponse<string[]> GetRoleClaimsByRoleId(int roleId)
        {
            return Response<string[]>.Success(_roleClaimDal.GetAll(r => r.RoleId == roleId).Select(r => r.Name).ToArray());
        }

        public IResponse Update(RoleClaim roleClaim)
        {
            throw new NotImplementedException();
        }
    }
}
