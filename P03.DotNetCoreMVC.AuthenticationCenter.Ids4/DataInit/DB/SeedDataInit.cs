

using System.Reflection;
using IdentityServer4.EntityFramework.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace P03.DotNetCoreMVC.AuthenticationCenter.Ids4.DataInit.DB
{
    public static class SeedDataInit
    {
        public static void InitSeedData(this IServiceCollection service, string connectionString)
        {
            string migtationAssembly = typeof(SeedDataInit).GetTypeInfo().Assembly.GetName().Name;
            service.AddConfigurationDbContext(
                options =>
                {
                    options.ConfigureDbContext =
                        db => db.UseSqlServer( connectionString, 
                            sql => sql.MigrationsAssembly(migtationAssembly));

                }

            );







        }


    }
}
