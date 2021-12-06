using Microsoft.Extensions.DependencyInjection;
using P05.IOCDI.Framework.CustomContainerFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomContainerIOC
{
    public class CustomServiceProvider : IServiceProvider
    {
        private IContainer _container = null;
        private IServiceCollection _iServiceCollection = null;

        public CustomServiceProvider(IContainer container)
        {
            this._container = container;
        }
        public CustomServiceProvider(IContainer container, IServiceCollection servicesCollection)
        {
            this._container = container;
            this._iServiceCollection = servicesCollection;
        }

        #region important

        // interface IServiceProvider require
        public object? GetService(Type serviceType)
        {
            try
            {
                return this._container.ResolveType(serviceType)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion



        public object? GetService<T>()
        {
            try
            {
                return this._container.Resolve<T>()!;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
