using System.Diagnostics.CodeAnalysis;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SimplCommerce.AcceptanceTests
{
    [Binding]
    public class TestsSetup
    {
        /// <summary>
        /// A static driver is needed because SpecFlow does not support a global context DI.
        /// It only supports it at a Scenario level.
        /// </summary>
        [SuppressMessage("Design", "CS8618", Justification = "Initialized in static hook before all tests.")]
        public static IWebDriver Driver { get; private set; }

        // TODO: Move to appSettings.json.
        public static class Config
        {
            public const string ConnectionString = $"Server=.\\SQLEXPRESS;Database=SimplCommerce;Trusted_Connection=True;";

            /// <summary>
            /// Regardless of page loading, some elements aren't yet attached to page.
            /// Therefore when interacting with them, you will get StaleElementReferenceException.
            /// Retrying a few times seems to help.
            /// </summary>
            public const int MaxTries = 5;
        }

        [BeforeTestRun]
        public static void InitializeDependencies()
        {
            Driver = BuildDriver();
        }

        [AfterTestRun]
        public static void CleanupDependencies()
        {
            Driver.Dispose();
        }

        private static IWebDriver BuildDriver()
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
