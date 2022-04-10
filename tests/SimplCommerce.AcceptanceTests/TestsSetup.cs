﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SolidToken.SpecFlow.DependencyInjection;

namespace SimplCommerce.AcceptanceTests
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