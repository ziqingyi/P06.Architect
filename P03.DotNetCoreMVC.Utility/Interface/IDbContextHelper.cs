using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DotNetCoreMVC.Utility.Interface
{
    public interface IDbContextHelper
    {
        public DbContext GetWriteDBContext();

        public DbContext[] GetReadDBContextList();


    }
}
