using P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst.ModelsFromDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.DotNetCoreMVC.EntityFrameworkModels.TestProject
{
    public class QueryTest
    {

        public static void Show()
        {
            using (advanced7Context dbcontext = new advanced7Context())
            {
                {
                    var list = dbcontext.SysUser.Where(u => 1 == 1 && !(new int[] { 1, 2, 3 }.Contains(u.Id)));


                }















            }

        }

    }
}
