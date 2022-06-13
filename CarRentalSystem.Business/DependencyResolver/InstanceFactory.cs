using Autofac;
using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Concrete;
using CarRentalSystem.DataAccess.Abstract;
using CarRentalSystem.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.DependencyResolver
{
    public class InstanceFactory
    {
        private static IContainer _container;

        public static T GetInstance<T>() 
        {
            if (_container == null)
            {
                var builder = new ContainerBuilder();
                builder.RegisterModule(new AutofacBusinessModule());
                _container = builder.Build();
            }
          
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<T>();
                return service;
            }
           
            
            



        }

      
    }
}
