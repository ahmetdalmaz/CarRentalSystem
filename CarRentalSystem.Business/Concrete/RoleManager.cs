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
    public class RoleManager : IRoleService
    {
        private IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public IResponse Add(Role operationClaim)
        {
            _roleDal.Add(operationClaim);
            return Response.Success();
        }

        public IResponse Delete(Role operationClaim)
        {
            _roleDal.Delete(operationClaim);
            return Response.Success();
        }

        public IDataResponse<List<Role>> GetOperationClaims()
        {
            return Response<List<Role>>.Success(_roleDal.GetAll());
            
        }

        public IResponse Update(Role operationClaim)
        {
            _roleDal.Update(operationClaim);
            return Response.Success();
        }
    }
}
