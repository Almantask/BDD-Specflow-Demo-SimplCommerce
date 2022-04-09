using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SimplCommerce.FunctionalTests.Extensions
{
    public static class IWebElementExtensions
    {
        public static IWebElement? GetParent(this IWebElement? webElement)
            => webElement?.FindElement(By.XPath(".//.."));
    }
}
