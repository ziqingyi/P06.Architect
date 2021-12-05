using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomContainerFolder
{
    public interface IContainer
    {
        #region Register

        //TService:class                TService must be a reference type (not a value type).
        void Register<TService,TImplementation>(string shortName = null, object[] paraList = null, RegisterLifeTimeType lifeTimeType = RegisterLifeTimeType.Transient) where TService:class where TImplementation : TService;

        void RegisterType(Type tService, Type tImplementation, string shortName = null, object[] paraList = null, RegisterLifeTimeType lifeTimeType = RegisterLifeTimeType.Transient);
        
        #endregion


        #region Resolve

        TService Resolve<TService>(string shortName = null);

        object ResolveType(Type type, string shortName = null);

        #endregion

        IContainer CreateChildContainer();

    }
}
