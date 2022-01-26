using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using P03.DotNetCoreMVC.Utility.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DotNetCoreMVC.Utility.DbContextExtension
{
    public class CustomDbContextFactory : ICustomDbContextFactory
    {
        private DbContext _dbContext;
        private DBConnectionOption _readAndWrite;

        //IOC inject db connections and DbContext.
        public CustomDbContextFactory(DbContext context, IOptionsMonitor<DBConnectionOption> options)
        {
            _readAndWrite = options.CurrentValue;
            this._dbContext = context;
        }

        public DbContext ConnWriteOrRead(WriteAndReadEnum writeAndRead)
        {
            throw new NotImplementedException();
        }
    }
}
