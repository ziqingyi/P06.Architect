using P05.IOCDI.Framework.CustomContainerFolder;
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

        public CustomContainerBuilder(IServiceCollection service)
        {


        }




    }
}
