using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimplCommerce.AcceptanceTests.HtmlElements;

namespace SimplCommerce.AcceptanceTests.Extensions
{
    public static class IWebDriverExtensions
    {
        public static HtmlTable FindTable(this IWebDriver driver, By by)
        {
            var tableWrapper = driver.FindElement(by);

            return new HtmlTable(tableWrapper);
        }
    }
}
