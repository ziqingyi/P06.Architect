using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P03.DotNetCoreMVC.Interface;


namespace P03.DotNetCoreMVC
{
    public class CommodityService:BaseService, ICommodityService
    {
        public CommodityService(DbContext context) : base(context)
        {

        }

    }
}
