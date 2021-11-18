using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomContainerFolder
{
    public class CustomContainer : IContainer
    {
        private Dictionary<string, Type> containerDic = new Dictionary<string, Type>();
        

        public void Register<TService, TImplementation>() where TImplementation : TService
        {
            this.containerDic.Add(typeof(TService).FullName!, typeof(TImplementation));
        }

        public TService Resolve<TService>()
        {

            TService instance = (TImplementation)this.Resolve(type);
            return instance;
        }



    }
}
