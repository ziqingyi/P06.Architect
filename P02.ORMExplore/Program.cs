using P02.ORMExplore.DAL;
using System;
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
            CompanyModel company3 = helper.Find<CompanyModel>(1);
            company3.CompanyName = company3.CompanyName + "updated";
            company3.CreateTime = DateTime.Now;
            helper.Insert(company3);

            #endregion






        }



    }
}
