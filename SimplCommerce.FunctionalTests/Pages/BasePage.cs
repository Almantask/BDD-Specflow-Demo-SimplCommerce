using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SimplCommerce.FunctionalTests.Pages
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
