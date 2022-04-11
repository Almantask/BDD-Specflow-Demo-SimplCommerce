using OpenQA.Selenium;
using SimplCommerce.AcceptanceTests.Utils;

namespace SimplCommerce.AcceptanceTests.Extensions
{
    public static class IWebElementExtensions
    {
        public static bool TryFindElement(this IWebElement element, By by, out IWebElement? result)
        {
            try
            {
                result = element.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                result = null;
                return false;
            }
        }

        public static IWebElement? GetParent(this IWebElement? webElement)
            => webElement?.FindElement(By.XPath(".//.."));
    }
}
