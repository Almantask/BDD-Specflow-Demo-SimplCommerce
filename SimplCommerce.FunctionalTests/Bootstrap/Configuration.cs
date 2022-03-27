using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimplCommerce.Module.Core.Data;

namespace SimplCommerce.FunctionalTests.Bootstrap
{
    public static class Configuration
    {
        /// <summary>
        /// Name for overriding default "production" environment.
        /// </summary>
        public const string AspnetcoreEnvironmentAutomatedTesting = "AutomatedTesting";

        /// <summary>
        /// Set the override of web host configuration.
        /// </summary>
        public static Action<IWebHostBuilder> WebhostConfiguration => builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.ReplaceDbWithInMemory();

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var logger = scopedServices.GetRequiredService<ILogger<TestServer<Program>>>();

                var employeeDbContext = scopedServices.GetRequiredService<SimplDbContext>();
                employeeDbContext.Database.EnsureCreated();

                try
                {
                    // Seed database
                    InitializeDbForTests(employeeDbContext);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred seeding the database with test messages. Error: {Message}", ex.Message);
                }
            });

        };

        private static void ReplaceDbWithInMemory(this IServiceCollection services)
        {
            var context = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<SimplDbContext>));
            services.Remove(context);

            services.AddDbContext<SimplDbContext>(options => { options.UseInMemoryDatabase("TestSimplDbContext"); });
        }

        private static void InitializeDbForTests(SimplDbContext context)
        {

        }
    }
}
