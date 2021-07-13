using P02.ORMExplore.DAL;
using System;
using System.Threading;
using P02.ORMExplore.Model.DbModels;

namespace P02.ORMExplore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ORM implementation");
            //Test1();
            //Test2();
            Test3();



        }

        private static void Test3()
        {
            #region insert by transaction

            using (SqlHelperTransaction helper = new SqlHelperTransaction())
            {
                CompanyModel company1 = helper.Find<CompanyModel>(1);
                User u1 = helper.Find<User>(1);
                company1.CompanyName += "-Tran";
                u1.Name = "error777777777777777777777777777777777777" +
                          "777777777777777777777777777777777777" +
                          "7777777777777777777777777777777";//test transaction error

                helper.Insert(company1);
                helper.Insert(u1);
                helper.SaveAllChangesInOneTransaction();
            }

            #endregion


        }

        private static void Test2()
        {
            #region Test with updating in demand, only update few columns from Json
            SqlHelper helper = new SqlHelper();
            CompanyModel company3 = helper.Find<CompanyModel>(1);
            company3.CompanyName = company3.CompanyName + "-newUpdate";
            company3.LastModifyTime = DateTime.Now;

            //prepare json, only for updated columns
            string newItemJson = Newtonsoft.Json.JsonConvert.SerializeObject(new {

                CompanyName = company3.CompanyName,
                LastModifyTime = company3.LastModifyTime
            });

            helper.Update(newItemJson,company3);

            //then delete
            helper.Delete(company3);

            #endregion
        }

        private static void Test1()
        {
            #region Test find and update and generic cache, then search, insert, update (new row), delete

            SqlHelper helper = new SqlHelper();
            //first time use generic type SqlBuilder will generate sql with that type, will use for next time with same class type. 
            CompanyModel company1 = helper.Find<CompanyModel>(1);
            User u1 = helper.Find<User>(1);

            //reuse sql, generic type cache. 
            //read from subscription database, write to write-db, check in subscription database
            CompanyModel company3 = helper.Find<CompanyModel>(1);
            company3.CompanyName = company3.CompanyName + "-new";
            company3.CreateTime = DateTime.Now;
            int newCompanyId = helper.Insert(company3);

            for (int i = 0; i < 10; i++)
            {
                CompanyModel newCompanyTemp = helper.Find<CompanyModel>(newCompanyId);

                if (newCompanyTemp == null)
                {
                    Console.WriteLine("not sync yet");
                }
                else
                {
                    Console.WriteLine($"find new in subscription database in {i * 500} ms");
                    break;
                }
                Thread.Sleep(500);
            }

            //update new value , note: the validation process 
            CompanyModel newCompany = helper.Find<CompanyModel>(newCompanyId);
            newCompany.CompanyName = newCompany.CompanyName + "-update";
            helper.Update(newCompany);

            //then delete
            helper.Delete(newCompany);

            #endregion
        }

    }
}
