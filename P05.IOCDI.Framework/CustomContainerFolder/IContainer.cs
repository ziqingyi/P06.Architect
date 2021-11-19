using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomContainerFolder
{
    public interface IContainer
    {
        //TService:class                TService must be a reference type (not a value type).
        void Register<TService,TImplementation>() where TService:class where TImplementation : TService;

        TService Resolve<TService>();
    }
}
