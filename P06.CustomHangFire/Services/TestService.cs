using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using P06.CustomHangFire.Interface;

namespace P06.CustomHangFire.Services
{
    public class TestService:ITest
    {
        private string connStr = "Data Source=.;Initial Catalog=advanced7;User ID=adrian;Password=adrian";


        public void InsertToDBTest2()
        {
            string sql = @"insert into TestTable([Name], CreateTime)
                              values ('testCompany', GETDATE())";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    int i = cmd.ExecuteNonQuery();

                }
            }
        }

   
        public void InsertToDBTest1()
        {
            string sql = @"insert into Company([Name], CreateTime,CreatorId,LastModifierId,LastModifyTime)
                              values ('testCompany', GETDATE(), 2,2 ,getdate())";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {

                    int i = cmd.ExecuteNonQuery();

                }
            }
        }






    }
}
