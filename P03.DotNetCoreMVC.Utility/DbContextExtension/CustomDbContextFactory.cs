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
        private IDbContextHelper _dbContextHelper;
        private DBConnectionOption _readAndWrite;
        
        private DbContext dbContextPicked = null;
        private int numOfReadDbContext = 0;

        //IOC inject db connections and DbContext.
        public CustomDbContextFactory(IDbContextHelper dbContextHelper, IOptionsMonitor<DBConnectionOption> options)  
        {
            this._dbContextHelper = dbContextHelper;
            this.numOfReadDbContext = dbContextHelper.GetReadDBContextList().Length;

            _readAndWrite = options.CurrentValue;        
        }

        public DbContext ConnWriteOrRead(WriteAndReadEnum writeAndRead)
        {
            
            switch(writeAndRead)
            {
                case WriteAndReadEnum.Write:
                    ToWrite();
                    break;
                case WriteAndReadEnum.Read:
                    ToRead();
                    break;
                default:
                    break;
            }

            return dbContextPicked;
        }


        #region get connection string for write or read operation. 

        private void ToWrite()
        {
            dbContextPicked = this._dbContextHelper.GetWriteDBContext();
        }

        private static int _iSeed = 0;
        private void ToRead()
        {
            if(_iSeed > 100000 )
            {
                _iSeed = 0;
            }

            int index = _iSeed++ % this.numOfReadDbContext;
            dbContextPicked = this._dbContextHelper.GetReadDBContextList()[index];
        }


        #endregion



    }
}
