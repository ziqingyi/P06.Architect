using P05.IOCDI.Framework.CustomContainerFolder.ContainerAttributes;
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
            if(!containerDic.ContainsKey( typeof(TService).FullName!  ))
            {
                this.containerDic.Add(typeof(TService).FullName!, typeof(TImplementation));
            }        
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

            #region IOC 


            #region find a ctor from the list, constructor discovery rules for Constructor injection behavior

            //find all ctors
            ConstructorInfo[] constractorArray = type.GetConstructors();

            //get ctor by attributes first
            ConstructorInfo ctor = constractorArray.FirstOrDefault(c => c.IsDefined(typeof(InjectionConstructorAttribute)));
            if (ctor == null)
            {
                //get ctor by length of parameters
                ctor = constractorArray.OrderBy(c => c.GetParameters().Length).Last();
            }

            #endregion


            #region get all parameters of this ctor
            var parameterArray = ctor.GetParameters();

            //resolve all parameters and add to list
            List<object> oParameterInstanceList = new List<object>();
            if (parameterArray != null && parameterArray.Length > 0)
            {
                foreach (var p in parameterArray)
                {
                    Type parameterType = p.ParameterType;
                    Type targetType = this.containerDic[parameterType.FullName!];
                    object parameterInsance = this.Resolve(targetType);//Activator.CreateInstance(targetType)!;
                    oParameterInstanceList.Add(parameterInsance);
                }
            }
            else
            {
                //iteration finish
            }
            #endregion



            #endregion






            #region create instance with reflection
            object oInstance = Activator.CreateInstance(type,oParameterInstanceList.ToArray())!;
            return oInstance;
            #endregion
        }


    }
}
