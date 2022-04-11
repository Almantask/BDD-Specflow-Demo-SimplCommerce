using OpenQA.Selenium;
using SimplCommerce.AcceptanceTests.HtmlElements;
using SimplCommerce.AcceptanceTests.Utils;

namespace SimplCommerce.AcceptanceTests.Extensions
{
    public static class IWebDriverExtensions
    {
        public static bool TryFindElement(this IWebDriver driver, By by, out IWebElement? result)
        {
            try
            {
                result = driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// Find element under which there is table
        /// </summary>
        /// <returns></returns>
        public static HtmlTable FindTableUsingWrapper(this IWebDriver driver, By by)
        {
            var tableWrapper = driver.FindElement(by);

            return HtmlTable.FromWrapperElement(tableWrapper);
        }

        /// <summary>
        /// Find table element itself.
        /// </summary>
        public static HtmlTable FindTableUsingBody(this IWebDriver driver, By by)
        {
            var tableElement = StaleElementAccessor.TryFind(() => driver.FindElement(by));
            return HtmlTable.FromTableElement(tableElement!);
        }
    }
}
