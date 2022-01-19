using P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst.ModelsFromDB;
using System;
using System.Linq;

namespace P03.DotNetCoreMVC.EntityFrameworkModels.TestProject
{
    public class Program
    {
        static void Main(string[] args)
        {
          

        }


        private void Test1()
        {
            using (advanced7Context context = new advanced7Context())
            {
                //delete and create database
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var AddUser = new User()
                {
                    //Id = 1,
                    Name = "user1111",
                    Account = "user1111",
                    Password = "password",
                    Email = "ss@gmail.com",
                    Mobile = "8888888",
                    CompanyName = "adfa",
                    State = 1,
                    UserType = 1,
                    CreateTime = DateTime.Now,
                    CreatorId = 1,
                    LastModifyTime = DateTime.Now,
                    LastModifierId = 1
                };

                context.User.Add(AddUser);
                context.SaveChanges();


                var Addcompany = new Company()
                {
                    Name = "Company1111",
                    CreateTime = DateTime.Now,
                    CreatorId = 1,
                    LastModifyTime = DateTime.Now,
                    LastModifierId = 1
                };

                context.Company.Add(Addcompany);
                context.SaveChanges();

                Company c1 = context.Company.Find(1);
                var cList = context.Company.Where(c => c.Id > 1);
            }


            Console.WriteLine("Hello World!");

        }
    }
}
