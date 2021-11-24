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

            TService instance = (TService)this.Resolve(typeof(TService));
            return instance;
        }

        //Resolve: create instance by DI
        private object Resolve(Type ServicType)
        {
            //find target type in register dictionary
            string keyType = ServicType.FullName!;
            if (!containerDic.ContainsKey(keyType))
            {
                throw new Exception($"{keyType} has not been registered");
            }
            Type targetType = this.containerDic[keyType];



            #region 1 Constructor injection: find a ctor from the list,set constructor discovery rules for injection behavior


            #region constructor discovery

            //find all ctors
            ConstructorInfo[] constractorArray = targetType.GetConstructors();

            //get ctor by attributes first
            ConstructorInfo ctor = constractorArray.FirstOrDefault(c => c.IsDefined(typeof(ConstructorInjectionAttribute)));
            if (ctor == null && constractorArray.Length > 0)
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
  
                    object parameterInsance = this.Resolve(parameterType);//Activator.CreateInstance(targetType)!;
                    oParameterInstanceList.Add(parameterInsance);
                }
            }
            else
            {
                //iteration finish
            }
            #endregion


            #region create instance with reflection
            object oInstance = Activator.CreateInstance(targetType, oParameterInstanceList.ToArray())!;

            #endregion


            #endregion




            #region 2  attribute injection after instance is created. 

            IEnumerable<PropertyInfo> allInjectionProperties = targetType.GetProperties().Where(p => p.IsDefined(typeof(MethodInjectionAttribute)));

            foreach (PropertyInfo property in allInjectionProperties)
            {
                Type Ptype = property.PropertyType;
                object propertyInstance = this.Resolve(Ptype);
                property.SetValue(oInstance, propertyInstance);

            }

            #endregion


            #region 3 method injection




            #endregion



            return oInstance;


        }


    }
}
