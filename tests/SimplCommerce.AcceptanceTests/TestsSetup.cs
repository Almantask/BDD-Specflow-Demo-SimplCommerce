using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SolidToken.SpecFlow.DependencyInjection;

namespace SimplCommerce.AcceptanceTests
{
    [Binding]
    public class TestsSetup
    {
        // TODO: Move to appSettings.json.
        /// <summary>
        /// 
        /// </summary>
        public static class Config
        {
            public const string ConnectionString = $"Server=.\\SQLEXPRESS;Database=SimplCommerce;Trusted_Connection=True;";

            /// <summary>
            /// Regardless of page loading, some elements don't appear fast enough.
            /// Therefore when interacting with them, you will get StaleElementReferenceException.
            /// Retrying a few times seems to help.
            /// </summary>
            public const int MaxRetries = 5;
        }



        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();
            // Register the step definition classes
            // Use any class as typeof target that would be within the same project.
            services.TryAddSingleton<IWebDriver>(BuildDriver);

            return services;
        }

        private static IWebDriver BuildDriver(IServiceProvider _)
        {
            var driver = new ChromeDriver();
            // Wait a bit for any element to appear to factor in loading times.
            // Default wait time is 0.
            // When you need to wait for more, use WaitDriver (from Selenium.WaitExtensions NuGet)
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
            return driver;
        }
    }
}
