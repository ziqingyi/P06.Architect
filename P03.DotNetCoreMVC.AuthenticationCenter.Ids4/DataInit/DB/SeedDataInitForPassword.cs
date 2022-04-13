

using System.Linq;
using System.Reflection;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.EntityFramework.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace P03.DotNetCoreMVC.AuthenticationCenter.Ids4.DataInit.DB
{
    public static class SeedDataInitForPassword
    {
        /* Configuration Store is used for encapsulating the configuration data and tables such as clients, resources and scopes,        
         * Operational Store is keeping the temporary data such as authorization codes and refresh tokens. 
         */
        public static void InitSeedDataForPassword(this IServiceCollection service, string connectionString)
        {
            string migtationAssembly = typeof(SeedDataInitForPassword).GetTypeInfo().Assembly.GetName().Name;
            service.AddConfigurationDbContext(
                options =>
                {
                    options.ConfigureDbContext =
                        db => db.UseSqlServer( connectionString, 
                            sql => sql.MigrationsAssembly(migtationAssembly));

                }
            );

            service.AddOperationalDbContext(options =>
            {
                options.ConfigureDbContext = 
                    db => db.UseSqlServer(connectionString,
                    sql => sql.MigrationsAssembly(migtationAssembly));
            });


            var serviceProvider = service.BuildServiceProvider();

            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<PersistedGrantDbContext>().Database.Migrate();
                var context = scope.ServiceProvider.GetService<ConfigurationDbContext>();
                context.Database.Migrate();
                InitCustomSeedData(context);
            }

        }
        // keep data in database, update with refresh ?
        private static void InitCustomSeedData(ConfigurationDbContext context)
        {
            #region clean existing data first

            if (context.Clients.Any())
            {
                context.Clients.RemoveRange(context.Clients);
                context.SaveChanges();
            }

            if (context.ApiResources.Any())
            {
                context.ApiResources.RemoveRange(context.ApiResources);
                context.SaveChanges();
            }
            if (context.ApiScopes.Any())
            {
                context.ApiScopes.RemoveRange(context.ApiScopes);
                context.SaveChanges();
            }            

            #endregion

            if (!context.Clients.Any())
            {
                foreach (var client in PasswordInitConfig.GetClients())
                {
                    context.Clients.Add(client.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var api in PasswordInitConfig.GetApiResources())
                    context.ApiResources.Add(api.ToEntity());
                context.SaveChanges();
            }

            if (!context.ApiScopes.Any())
            {
                foreach (var scope in PasswordInitConfig.ApiScopes())
                {
                    context.ApiScopes.Add(scope.ToEntity());
                }
                context.SaveChanges();
            }


            //if (!context.IdentityResources.Any())
            //{
            //    foreach (var id in PasswordInitConfig.GetIdentityResources())
            //        context.IdentityResources.Add(id.ToEntity());
            //    context.SaveChanges();
            //}

            //init User
        }
    }
}
