using OpenQA.Selenium;

namespace SimplCommerce.AcceptanceTests.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver { get; }

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        protected void NavigateTo(string url)
        {
            if (Driver.Url == url) return;

            Driver.Navigate().GoToUrl(url);
        }
    }
}
