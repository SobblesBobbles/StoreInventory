using Autofac;
using Autofac.Integration.Mvc;
using StoreInventory.BLL;
using StoreInventory.BLL.Interfaces;
using StoreInventory.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreInventory.App_Start
{
    public static class ContainerConfig
    {

        public static IContainer RegisterContainers()
        {
            var builder = new ContainerBuilder();

            object p = builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new AutofacWebTypesModule());
            builder.RegisterType<DatabaseContext>().As<DatabaseContext>().InstancePerRequest();
            builder.RegisterType<DataManager>().As<IDataManager>().InstancePerRequest();
            //builder.RegisterType<InteractionManager>().As<IInteractionManager>().InstancePerRequest();
            //builder.RegisterType<StatisticsManager>().As<IStatisticsManager>().InstancePerRequest();
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            return container;

        }
    }
}