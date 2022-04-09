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

        /// <summary>
        /// Sometimes WebElement is in a stale state.
        /// A retry might be required.
        /// </summary>
        /// <returns></returns>
        public static IWebElement TryClicking(this IWebElement? element, int maxTries)
        {
            while (maxTries > 0)
            {
                try
                {
                    element.Click();
                }
                catch (StaleElementReferenceException)
                {
                    maxTries--;
                }
            }

            return element;
        }
    }
}
