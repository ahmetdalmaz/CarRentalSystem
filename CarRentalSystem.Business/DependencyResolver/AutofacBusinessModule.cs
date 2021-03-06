using Autofac;
using Autofac.Extras.DynamicProxy;
using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Concrete;
using CarRentalSystem.Business.Utilities.Interceptors;
using CarRentalSystem.DataAccess.Abstract;
using CarRentalSystem.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.DependencyResolver
{
    public class AutofacBusinessModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<SegmentManager>().As<ISegmentService>().SingleInstance();
            builder.RegisterType<EfSegmentDal>().As<ISegmentDal>().SingleInstance();

            builder.RegisterType<ModelManager>().As<IModelService>().SingleInstance();
            builder.RegisterType<EfModelDal>().As<IModelDal>().SingleInstance();

            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();

            builder.RegisterType<RoleClaimManager>().As<IRoleClaimService>().SingleInstance();
            builder.RegisterType<EfRoleClaim>().As<IRoleClaimDal>().SingleInstance();

            builder.RegisterType<RoleManager>().As<IRoleService>().SingleInstance();
            builder.RegisterType<EfRoleDal>().As<IRoleDal>().SingleInstance();

        }
    }
}
