using System;

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
            Console.WriteLine("Hello World!");
        }
    }
}
