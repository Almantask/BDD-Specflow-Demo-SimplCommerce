using OpenQA.Selenium;
using SimplCommerce.AcceptanceTests.HtmlElements;

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
