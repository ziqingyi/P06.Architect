using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomContainerIOC
{
    //host builder method: IHostBuilder UseServiceProviderFactory<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory);
    public class CustomContainerFactory:IServiceProviderFactory<CustomContainerBuilder>
    {
        public CustomContainerBuilder CreateBuilder(IServiceCollection services)
        {
            return new CustomContainerBuilder(services);
        }


        public IServiceProvider CreateServiceProvider(CustomContainerBuilder containerBuilder)
        {
            return containerBuilder.GetServiceProvider();
        }



    }
}
