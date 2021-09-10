using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.EntityFrameworkCore;
using P03.DotNetCoreMVC.EntityFrameworkModels;
using P03.DotNetCoreMVC.Interface;

namespace P03.DotNetCoreMVC.AuthenticationCenter.ProjectUtility.AutofacUtility
{
    public class CustomAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            #region for all controllers
            //var assembly = this.GetType().GetTypeInfo().Assembly;
            //var builder = new ContainerBuilder();
            //var manager = new ApplicationPartManager();
            //manager.ApplicationParts.Add(new AssemblyPart(assembly));
            //manager.FeatureProviders.Add(new ControllerFeatureProvider());
            //var feature = new ControllerFeature();
            //manager.PopulateFeature(feature);
            //builder.RegisterType<ApplicationPartManager>().AsSelf().SingleInstance();
            //builder.RegisterTypes(feature.Controllers.Select(ti => ti.AsType()).ToArray()).PropertiesAutowired();

            #endregion



            #region register AOP

            //containerBuilder.Register(c => new CustomAutofacAop());

            #endregion



            #region Add service IOC

            //default container IOC : inject by ctor only.  find superset of all ctors. 

            #region add EF DbContext

            containerBuilder.RegisterType<JDDbContext>().As<DbContext>().InstancePerLifetimeScope();

            //services.AddEntityFrameworkSqlServer()
            //    .AddDbContext<JDDbContext>(options => { options.UseSqlServer(StaticConstraint.connectionString); });

            #endregion

            containerBuilder.RegisterType<UserService>().As<IUserService>();


            //containerBuilder.RegisterType<TestServiceA>().As<ITestServiceA>().SingleInstance().PropertiesAutowired();




            #endregion

        }


    }
}
