using Ninject;
using RentACar.Dal.Abstract;
using RentACar.Dal.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RentACar.WebUI.NinjectController
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBllBindings();
        }
        private void AddBllBindings()
        {
            ninjectKernel.Bind<IAdminDal>().To<EfAdminDal>();
            ninjectKernel.Bind<IBranchDal>().To<EfBranchDal>();
            ninjectKernel.Bind<ICarDal>().To<EfCarDal>();
            ninjectKernel.Bind<IFuelTypeDal>().To<EfFuelTypeDal>();
            ninjectKernel.Bind<IGearTypeDal>().To<EfGearTypeDal>();
            ninjectKernel.Bind<IVehicleDal>().To<EfVehicleDal>();
            ninjectKernel.Bind<IVehicleTypeDal>().To<EfVehicleTypeDal>();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
    }

}