using P03.DotNetCoreMVC.Interface;
using P03.DotNetCoreMVC.Interface.ServiceInterfaceUpgrade;
using P03.DotNetCoreMVC.Utility.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DotNetCoreMVC.Services.ServicesUpgrade
{
    public class CompanyServiceUpgrade : BaseServiceUpgrade, ICompanyServiceUpgrade
    {
        public CompanyServiceUpgrade(ICustomDbContextFactory dbContextFactory) : base(dbContextFactory)
        {

        }


        public void TestCompanyServiceError()
        {
            throw new NotImplementedException();
        }
    }
}
