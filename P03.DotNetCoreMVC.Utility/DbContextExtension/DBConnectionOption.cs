using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DotNetCoreMVC.Utility.DbContextExtension
{
    public class DBConnectionOption
    {
        public string WriteConnection { get; set; }

        public List<string> ReadConnectionList { get; set; }

    }
}
