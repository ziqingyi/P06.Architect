using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using P03.DotNetCoreMVC.Interface;
using P03.DotNetCoreMVC.Interface.TestServiceInterface;
using P03.DotNetCoreMVC.ProjectUtility.InterceptService;
using P03.DotNetCoreMVC.Services;
using P03.DotNetCoreMVC.Services.ServicesUpgrade;

namespace P03.DotNetCoreMVC.ProjectUtility.AutofacUtility
{
    public class CustomAutofacModule: Autofac.Module
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

            containerBuilder.Register(c => new CustomAutofacAop());

            #endregion


            #region Register for IOC

            //containerBuilder.RegisterType<FirstController>().PropertiesAutowired();
            //containerBuilder.RegisterType<TestServiceA>().As<ITestServiceA>().SingleInstance().PropertiesAutowired();
            //containerBuilder.RegisterType<TestServiceC>().As<ITestServiceC>();
            //containerBuilder.RegisterType<TestServiceB>().As<ITestServiceB>();
            //containerBuilder.RegisterType<TestServiceD>().As<ITestServiceD>();
            //containerBuilder.RegisterType<TestServiceE>().As<ITestServiceE>();

            //containerBuilder.RegisterType<A>().As<IA>();//.EnableInterfaceInterceptors();

            //containerBuilder.Register<FirstController>();

            //containerBuilder.RegisterType<JDDbContext>().As<DbContext>();
            //containerBuilder.RegisterType<CategoryService>().As<ICategoryService>();

            containerBuilder.RegisterType<UserService>().As<IUserService>();

            containerBuilder.RegisterType<A>().As<IA>();


            //containerBuilder.RegisterType<CompanyServiceUpgrade>().As<ICompanyServiceUpgrade>();

            #endregion

        }







    }
}
