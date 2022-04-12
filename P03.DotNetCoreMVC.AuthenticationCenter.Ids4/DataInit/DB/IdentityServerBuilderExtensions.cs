using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace P03.DotNetCoreMVC.AuthenticationCenter.Ids4.DataInit.DB
{
    public static class IdentityServerBuilderExtensions
    {
        //public static IIdentityServerBuilder AddEFConfigurationStore(this IIdentityServerBuilder builder,
        //    string connectionString)
        //{
        //    string assemblyNameSpace = typeof(Microsoft.Extensions.DependencyInjection.IdentityServerBuilderExtensions)
        //        .GetTypeInfo()
        //        .Assembly
        //        .GetName()
        //        .Name;

        //    builder.AddConfigurationStore(options =>
        //        options.ConfigureDbContext = b =>
        //            b.UseSqlServer(connectionString, optionsBuilder =>
        //                optionsBuilder.MigrationsAssembly(assemblyNameSpace)
        //            )
        //    );

        //    return builder;
        //}


    }
}
