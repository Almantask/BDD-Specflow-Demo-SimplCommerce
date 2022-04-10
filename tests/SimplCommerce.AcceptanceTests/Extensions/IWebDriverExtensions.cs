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
        public static HtmlTable FindTableUsingWrapper(this IWebDriver driver, By by)
        {
            var tableWrapper = driver.FindElement(by);

            return HtmlTable.FromWrapperElement(tableWrapper);
        }

        public static HtmlTable FindTableUsingBody(this IWebDriver driver, By by)
        {
            var tableElement = driver.FindElement(by);

            return HtmlTable.FromTableElement(tableElement);
        }
    }
}
