using Microsoft.EntityFrameworkCore;
using P03.DotNetCoreMVC.Utility.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DotNetCoreMVC.Utility.DbContextExtension
{
    public class ICustomDbContextFactory : Interface.ICustomDbContextFactory
    {





        public DbContext ConnWriteOrRead(WriteAndReadEnum writeAndRead)
        {
            throw new NotImplementedException();
        }
    }
}
