using Microsoft.EntityFrameworkCore;
using P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst2;
using P03.DotNetCoreMVC.Utility.Interface;
using System.Collections.Generic;

namespace P03.DotNetCoreMVC.Models
{
    public class DbContextHelper: IDbContextHelper
    {
        private DbContext _dbContext;

        private string[] readConnStringFromConfig = 
            { "Data Source=.;Initial Catalog=EFCoreContext_subscription;User ID=adrian;Password=adrian",
      "Data Source=.;Initial Catalog=EFCoreContext_subscription2;User ID=adrian;Password=adrian"};

        public DbContextHelper()//DbContext dbContext
        {
            DbContext dbContext = new EFCoreContextContext();

            this._dbContext = dbContext;
        }

        public DbContext GetWriteDBContext()
        {
            return _dbContext;
        }

        public DbContext[] GetReadDBContextList()
        {
            List<DbContext> list = new List<DbContext>();
            EFCoreContextContext dbContext = new EFCoreContextContext();
            foreach (string connString in readConnStringFromConfig)
            {
                dbContext.conn = connString;

                list.Add(dbContext);
            }
            return list.ToArray();
        }


    }
}
