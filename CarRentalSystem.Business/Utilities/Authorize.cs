using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Concrete;
using CarRentalSystem.Business.Utilities.Interceptors;
using CarRentalSystem.DataAccess.Concrete.EntityFramework;
using CarRentalSystem.Entities.Concrete;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Utilities
{
   
    public class Authorize:MethodInterception
    {
        
        private string[] _roles;
      
        string[] claims = {"personel" };

        public Authorize(string roles)
        {
        
            _roles = roles.Split(",");
         
         
        }
        protected override void OnBefore(IInvocation invocation)
        {
            foreach (var role in _roles)
            {
                if (claims.Contains(role))
                {
                    return;

            }
           
            throw new SecurityException("Bu işlem için yetkiniz yoktur");
            
     
        }


                }

    }
}
