using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst2;
using P03.DotNetCoreMVC.Utility.DbContextExtension;
using P03.DotNetCoreMVC.Utility.Interface;
using System.Collections.Generic;

namespace P03.DotNetCoreMVC.Models
{
    public class DbContextHelper: IDbContextHelper
    {
        private DbContext _dbContextWrite;

        //  private string[] readConnStringFromConfig = 
        //      { "Data Source=.;Initial Catalog=EFCoreContext_subscription;User ID=adrian;Password=adrian",
        //"Data Source=.;Initial Catalog=EFCoreContext_subscription2;User ID=adrian;Password=adrian"};

        private List<DbContext> _dbContextReadList = new List<DbContext>();
        public DbContextHelper(IOptionsMonitor<DBConnectionOption> optionsMonitor)//(DBConnectionOption dBConnectionOption)//DbContext dbContext
        {
            DBConnectionOption dBConnectionOption = optionsMonitor.CurrentValue;

            EFCoreContextContext dbContext = new EFCoreContextContext();
            dbContext.conn = dBConnectionOption.WriteConnection;
            this._dbContextWrite = dbContext;

            //prepare read DbContext
            foreach (string connString in dBConnectionOption.ReadConnectionList)
            { 
                EFCoreContextContext dbContextRead = new EFCoreContextContext();

                dbContextRead.conn = connString;

                _dbContextReadList.Add(dbContextRead);
            }      
        }

        public DbContext GetWriteDBContext()
        {
            return _dbContextWrite;
        }

        public DbContext[] GetReadDBContextList()
        {
            return _dbContextReadList.ToArray();
        }


    }
}
