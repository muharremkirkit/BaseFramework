using Autofac;
using Autofac.Integration.Mvc;
using BaseFramework.DAL;
using BaseFrameWork.Core.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;

namespace BaseFramework.MapConfig.ConfigProfile
{
    public class IocContainerConfig
    { //autofac referanslara eklendi ve Nlog eklendi
        //autofac dependencyinjection kuruldu referanslara eklendi
        //autofac mv5 kuruldu
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.Load("BaseFramework.UI")); //Buraya Web UI gelecek

            builder.RegisterType<BaseFrameworkEntities>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterType<UnıtofWork>().As<IUnıtofWork>().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.Load("BaseFramework.Busines"))
                .Where(z=> z.Name.EndsWith("Service")) //sonu service ile bitenleri getir
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            
        }
    }
}
