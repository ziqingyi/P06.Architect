using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomContainerFolder
{
    public class RegisterTypeModel
    {
        public Type TargetType { get; set; }

        public RegisterLifeTimeType LifeTimeType { get; set; }

        public object SingletonInstance { get; set; }

    }


    public enum RegisterLifeTimeType
    {
        Transient,
        Scope,
        Singleton,
        PerThread
    }



}
