using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P03.DotNetCoreMVC.Interface;


namespace P03.DotNetCoreMVC
{
    public class CompanyService:BaseService, ICompanyService
    {
        //construct super class first and then subclass.
        public CompanyService(DbContext context):base(context)
        {
           
        }

        public void TestCompanyServiceError()
        {
            throw new NotImplementedException();
        }


    }
}
