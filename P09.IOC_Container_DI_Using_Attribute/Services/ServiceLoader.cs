using P09.IOC_Container_DI_Using_Attribute.CustomAttributes;
using System.Reflection;

namespace P09.IOC_Container_DI_Using_Attribute.Services
{
    public class ServiceLoader
    {
        private static object _lock = new object();
        private static ServiceLoader _inst;
        private readonly IServiceCollection _iocService = new ServiceCollection();
        private readonly ICollection<Assembly> _iocAssembly = new HashSet<Assembly>();
        private IServiceProvider _iocServiceProvider = null;


        public static ServiceLoader Instance
        {
            get
            {
                if (_inst == null)
                {
                    lock (_lock)
                    {
                        _inst = new ServiceLoader();
                        _inst.Startup(typeof(ServiceLoader).Assembly);
                    }
                }
                return _inst;
            }
        }

        public T GetService<T>()
        {
            EnsureAutoIoc<T>();
            return _iocServiceProvider.GetService<T>();
        }

        private void EnsureAutoIoc<T>()
        {
            Startup(typeof(T).Assembly);
        }

        public void Startup(Assembly ass)
        {
            if (_iocAssembly.Any(x => x == ass))
            {
                return;
            }
            _iocAssembly.Add(ass);

            var types = ass.GetTypes().Where(x => x.GetCustomAttribute<AutowiredAttribute>() != null);
            foreach (var item in types)
            {
                var autoIocAtt = item.GetCustomAttribute<AutowiredAttribute>();
                AddTransient(autoIocAtt.Iface, item);
            }
            //_iocServiceProvider = _iocService.BuildServiceProvider();
            Interlocked.Exchange(ref _iocServiceProvider, _iocService.BuildServiceProvider());
        }

        private void AddTransient(Type iface, Type impl)
        {
            _iocService.AddTransient(iface, impl);
        }
    }
}
