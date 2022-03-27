using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Host.Extensions;
using SimplCommerce.Infrastructure;
using SimplCommerce.Module.Core.Data;

namespace SimplCommerce.Host
{
    public class MigrationSimplDbContextFactory : IDesignTimeDbContextFactory<SimplDbContext>
    {
        public SimplDbContext CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var contentRootPath = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder()
                            .SetBasePath(contentRootPath)
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{environmentName}.json", true);

            builder.AddUserSecrets(typeof(MigrationSimplDbContextFactory).Assembly, optional: true);
            builder.AddEnvironmentVariables();
            var _configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();
            GlobalConfiguration.ContentRootPath = contentRootPath;
            services.AddModules();
            services.AddCustomizedDataStore(_configuration);
            var _serviceProvider = services.BuildServiceProvider();

            return _serviceProvider.GetRequiredService<SimplDbContext>();
        }
    }
}
