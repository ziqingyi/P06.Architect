﻿using P05.IOCDI.Framework.CustomContainerFolder.ContainerAttributes;
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
        //private Dictionary<string, Type> containerDic = new Dictionary<string, Type>();
        private Dictionary<string, RegisterTypeModel> containerDic = new Dictionary<string, RegisterTypeModel>();

        private Dictionary<string, object> scope_ContainerDic = new Dictionary<string, object>();

        public IContainer CreateChildContainer()
        {
            CustomContainer container = new CustomContainer()
            {
                containerDic = this.containerDic,
                scope_ContainerDic = new Dictionary<string, object>()
            };

            return container;
        }


        public void Register<TService, TImplementation>( RegisterLifeTimeType lifeTimeType = RegisterLifeTimeType.Transient ) where TService : class where TImplementation : TService
        {
            if(!containerDic.ContainsKey( typeof(TService).FullName!  ))
            {
                //this.containerDic.Add(typeof(TService).FullName!, typeof(TImplementation));
                this.containerDic.Add(typeof(TService).FullName, new RegisterTypeModel()
                {
                    TargetType = typeof(TImplementation),
                    LifeTimeType = lifeTimeType,
                    SingletonInstance = null
                }) ;
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
            
            #region check register dictionary and find target type in register dictionary

            string keyType = ServicType.FullName!;

            if (!containerDic.ContainsKey(keyType))
            {
                throw new Exception($"{keyType} has not been registered");
            }

            var model = containerDic[keyType];

            //if(model.LifeTimeType == RegisterLifeTimeType.Singleton && model.SingletonInstance != null)
            //{
            //    return model.SingletonInstance;
            //}
            switch(model.LifeTimeType)
            {
                case RegisterLifeTimeType.Transient:
                    break;
                case RegisterLifeTimeType.Scope:

                    if(scope_ContainerDic.ContainsKey(model.TargetType.FullName!))
                    {
                        return scope_ContainerDic[model.TargetType.FullName!];
                    }
                    break;
                case RegisterLifeTimeType.Singleton:
                    if(model.SingletonInstance != null)
                    {
                        return model.SingletonInstance;
                    }
                    break;
                default:
                    break;
            }
               
            Type targetType = this.containerDic[keyType]?.TargetType!;

            #endregion

            



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



            #region set life time type for instance 

            //if(model.LifeTimeType == RegisterLifeTimeType.Singleton)
            //{
            //    model.SingletonInstance = oInstance;
            //}

            switch (model.LifeTimeType)
            {
                case RegisterLifeTimeType.Transient:
                    break;
                case RegisterLifeTimeType.Scope:
                    if (!scope_ContainerDic.ContainsKey(model.TargetType.FullName!))
                    {
                        scope_ContainerDic[model.TargetType.FullName!] = oInstance;                    
                    }
                    break;
                case RegisterLifeTimeType.Singleton:
                    if (model.SingletonInstance == null)
                    {
                        return model.SingletonInstance = oInstance;
                    }
                    break;
                default:
                    break;
            }

            #endregion



            return oInstance;


        }


    }
}