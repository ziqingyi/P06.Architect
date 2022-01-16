using System;

namespace P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst
{

    //must confirm all projects can compile through
    /*
     * 
     * Scaffold-DbContext -Connection "Server=.;Database=advanced7;uid=adrian;pwd=adrian;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "ModelsFromDB"
     * 
     * 
     * add-Migration Init01
     * 
     * 1 Enable-Migrations: Enables the migration in your project by creating a Configuration class.
     * 
     * 2 Add-Migration: Creates a new migration class as per specified name with the Up() and Down() methods.
     * 
     * 3 Update-Database: Executes the last migration file created by the Add-Migration command and applies changes to the database schema.
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
