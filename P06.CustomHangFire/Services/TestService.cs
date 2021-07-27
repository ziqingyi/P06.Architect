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
        private string connStr = @"";


        public void Show()
        { 
            WriteToDB();
        }

        private void WriteToDB()
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
