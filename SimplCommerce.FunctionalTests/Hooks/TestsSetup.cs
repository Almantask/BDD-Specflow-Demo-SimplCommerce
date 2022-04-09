using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SimplCommerce.FunctionalTests.Pages;
using SolidToken.SpecFlow.DependencyInjection;

namespace SimplCommerce.FunctionalTests.Hooks
{
    [Binding]
    public class TestsSetup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();
            // Register the step definition classes
            // Use any class as typeof target that would be within the same project.
            services.TryAddSingleton<IWebDriver, ChromeDriver>();
            services.TryAddScoped<ShoppingCartPage>();

            return services;
        }
    }
}
