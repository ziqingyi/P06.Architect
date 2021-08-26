using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P03.DotNetCoreMVC.Interface;


namespace P03.DotNetCoreMVC
{
    public class UserCompanyService : BaseService,IUserCompanyService
    {
        public UserCompanyService(DbContext context) : base(context)
        {

        }

        public bool RemoveCompanyAndUser(int companyId)
        {
            return true;
        }

        public override void Dispose()
        {
            Console.WriteLine("dispose sth else");
            base.Dispose();
        }
    }
}
