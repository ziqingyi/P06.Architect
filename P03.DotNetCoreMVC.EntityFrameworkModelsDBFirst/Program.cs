using P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst.ModelsFromDB;
using System;
using System.Linq;

namespace P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst
{

    //must confirm all projects can compile through
    /*
     *  Database First
     * Scaffold-DbContext -Connection "Server=.;Database=advanced7;uid=adrian;pwd=adrian;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "ModelsFromDB"
     * 
     * 
     * 
     * 
     * Code-Based Migration in Entity Framework : 
     * 
     * 1 update code
     * 
     * 2 update Context class: advanced7Context  and pointing to new database name, then
     * 
     * 3 add-Migration Init01
     *                                add-Migration Init02
     *                               add-Migration Init03
     * 
     *  4 update-Database
     * 
     * (1) Add-Migration: Creates a new migration class as per specified name with the Up() and Down() methods.
     * 
     * (2) Update-Database: Executes the last migration file created by the Add-Migration command and applies changes to the database schema.
     * 
     * 
     */
    public class Program
    {

        public static void Main(string[] args)
        {
            using (advanced7Context context = new advanced7Context())
            {
                //delete and create database
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                
                    var Addcompany = new Company()
                    {
                        Name = "user1111",
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
