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
            SqlHelper helper = new SqlHelper();
            CompanyModel company = helper.Find<CompanyModel>(1);
            company.CompanyName = company.CompanyName + "updated";
            helper.Insert(company);



        }



    }
}
