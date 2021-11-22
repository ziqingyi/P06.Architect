using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomContainerFolder
{
    public class CustomContainer : IContainer
    {
        private Dictionary<string, Type> containerDic = new Dictionary<string, Type>();
        

        public void Register<TService, TImplementation>() where TService : class where TImplementation : TService
        {
            this.containerDic.Add(typeof(TService).FullName!, typeof(TImplementation));
        }

        public TService Resolve<TService>()
        {
            string key = typeof(TService).FullName!;
            if(!containerDic.ContainsKey(key))
            {
                throw new Exception($"{key} not registered");
            }
            Type type = containerDic[key];

            TService instance = (TService)this.Resolve(type);
            return instance;
        }

        private object Resolve(Type type)
        {

            #region 1 IOC 
            //find all ctors
            ConstructorInfo[] constractorArray = type.GetConstructors();

            #region find a ctor from the list

            ConstructorInfo ctor0 = constractorArray[0];



            #endregion

            //get all parameters of this ctor
            var parameterArray = ctor0.GetParameters();

            //
            List<object> oParameterInstanceList = new List<object>();
            foreach (var p in parameterArray)
            {
                Type parameterType = p.ParameterType;
                Type targetType = this.containerDic[parameterType.FullName!];
                object parameterInsance = Activator.CreateInstance(targetType)!;
                oParameterInstanceList.Add(parameterInsance);
            }

            #endregion






            #region create instance with reflection
            object oInstance = Activator.CreateInstance(type,oParameterInstanceList.ToArray())!;
            return oInstance;
            #endregion
        }


    }
}
