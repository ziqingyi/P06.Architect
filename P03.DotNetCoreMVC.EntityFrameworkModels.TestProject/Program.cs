using P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst.ModelsFromDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace P03.DotNetCoreMVC.EntityFrameworkModels.TestProject
{
    public class Program
    {
        static void Main(string[] args)
        {

            //TestEnumerable();
            //TestPerformance();

            TestLinqSql();
            TestDeleteAndCreate();

            QueryTest.Show();

        }
        private static void TestPerformance()
        {

            var seq = Enumerable.Range(0,10);
            var a = seq.First();
            var b = seq.Select(s => s/2 == 0);
            foreach (var item in b)
            {
                Console.WriteLine(item);
            }

        }
        private static void TestEnumerable()
        {    
            
            var numbers = GetNumbers();
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }


            var count = numbers.Count();
            var s = numbers.Sum();
            var max = numbers.Max();
            var min = numbers.Min();

            #region test
            /*        
            var res = Enumerable.Range(0, 5);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------");
            var res2 = res.Select(n => rand.Next(0, 10));
            foreach (var item in res2)
            {
                Console.WriteLine(item);
            }
            */
            #endregion

        }
        private static Random rand = new Random();
        private static IEnumerable<int> GetNumbers()
        {
            var count = rand.Next(0,10);
            return Enumerable.Range(0, count).Select(n => rand.Next(0,10));
        }


        private static void TestLinqSql()
        {
            
            using (advanced7Context context = new advanced7Context())
            {
                int i = 0;
                var list1 = context.User.Where(u => u.Id > 200);

                var a = list1.First();
                foreach (var item in list1)
                {
                    Console.WriteLine(i++ + "--"+item.Account);
                }
                Console.WriteLine("************************************************");
                var b1 = context.User.Where(u => u.Id > 200).OrderBy(m => m.Id);

                i = 0;
                foreach (var item in b1)
                {
                    Console.WriteLine(i++ + "--" + item.Account);
                }

                var b2 = context.User.Where(u => u.Id > 200).OrderBy("Id asc");

                i = 0;
                foreach (var item in b2)
                {
                    Console.WriteLine(i++ + "--" + item.Account);
                }

            }
            using (advanced7Context context = new advanced7Context())
            {
                int i = 0;
                var list2 = context.User.AsEnumerable<User>().Where(u => u.Id > 200);

                var b = list2.First();
                foreach (var item in list2)
                {
                    Console.WriteLine(i++ + "--" + item.Account);
                }
            }


        }

        private static void TestDeleteAndCreate()
        {
            using (advanced7ContextNew context = new advanced7ContextNew())
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
