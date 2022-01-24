using System;
using System.Collections.Generic;
using System.Text;
using P03.DotNetCoreMVC.Interface.ServiceInterfaceUpgrade;
using P03.DotNetCoreMVC.Utility.DbContextExtension;

namespace P03.DotNetCoreMVC.Services.ServicesUpgrade
{
    public class BaseServiceUpgrade : IBaseServiceUpgrade
    {

        protected ICustomDbContextFactory dbContextFactory = null;
                  



        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
