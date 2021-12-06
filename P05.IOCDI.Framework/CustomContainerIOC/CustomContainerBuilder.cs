using P05.IOCDI.Framework.CustomContainerFolder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomContainerIOC
{
    public class CustomContainerBuilder
    {
        private static IContainer _container = new CustomContainer();

        public CustomContainerBuilder(IServiceCollection services)
        {

            this.ServiceCollectionToCustomContainer(services);

        }

        public void ServiceCollectionToCustomContainer(IServiceCollection services)
        {
            foreach (var service in services)
            {
                if(service.ImplementationInstance != null)
                {
                    _container.RegisterType(service.ServiceType, service.GetType());
                }
                else
                {
                    _container.RegisterType(service.ServiceType, service.ImplementationType, lifeTimeType: this.LifetimeTypeTranslation(service.Lifetime));
                }
            }
        }


        public IServiceProvider GetServiceProvider()
        {
            return new CustomServiceProvider(_container);
        }


        public void RegisterType<TService, TImplementation>(string shortName = null, object[] paraList = null, RegisterLifeTimeType lifeTimeType = RegisterLifeTimeType.Transient) where TService : class where TImplementation : TService
        {
            _container.Register<TService, TImplementation>(shortName,paraList,lifeTimeType);
        }

        private RegisterLifeTimeType LifetimeTypeTranslation(ServiceLifetime lifeTime)
        {
            switch(lifeTime)
            {
                case ServiceLifetime.Transient:
                    return RegisterLifeTimeType.Transient;
                    break;
                case ServiceLifetime.Scoped:
                    return RegisterLifeTimeType.Scope;
                    break;
                case ServiceLifetime.Singleton:
                    return RegisterLifeTimeType.Singleton;
                    break;
                default:
                    return RegisterLifeTimeType.Transient;
                    break;
            }

        }

    }
}
