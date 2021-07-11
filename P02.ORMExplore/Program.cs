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
            #region Test find and update and generic cache
            
            SqlHelper helper = new SqlHelper();
            //first time use generic type SqlBuilder will generate sql with that type, will use for next time with same class type. 
            CompanyModel company1 = helper.Find<CompanyModel>(1);
            User u1 = helper.Find<User>(1);

            //reuse sql, generic type cache. 
            //read from subscription database, write to write-db, check in subscription database
            CompanyModel company3 = helper.Find<CompanyModel>(1);
            company3.CompanyName = company3.CompanyName + "updated";
            company3.CreateTime = DateTime.Now;
            int newCompanyId = helper.Insert(company3);

            for (int i = 0; i < 10; i++)
            {
                CompanyModel newCompany = helper.Find<CompanyModel>(newCompanyId);

                if (newCompany == null)
                {
                    Console.WriteLine("not sync yet");
                }
                else
                {
                    Console.WriteLine($"find new in subscription database in {i*500} ms" );
                    break;
                }
                Thread.Sleep(500);
            }



            #endregion






        }



    }
}
