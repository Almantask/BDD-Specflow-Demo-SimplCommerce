using SimplCommerce.AcceptanceTests.HtmlElements;

namespace SimplCommerce.AcceptanceTests.Extensions
{
    public static class IWebDriverExtensions
    {
        public static IWebElement? FindElementOrDefault(this IWebDriver driver, By by, params By[] nestedBys)
        {
            try
            {
                var element = driver.FindElement(by);
                foreach (var nestedBy in nestedBys)
                {
                    element = element.FindElement(nestedBy);
                }

                return element;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        /// <summary>
        /// Find element under which there is table.
        /// And then convert that to an HtmlTable.
        /// </summary>
        public static HtmlTable FindTable(this IWebDriver driver, By by)
        {
            var tableWrapper = driver.FindElement(by);
            return HtmlTable.FromWebElement(tableWrapper);
        }
    }
}
