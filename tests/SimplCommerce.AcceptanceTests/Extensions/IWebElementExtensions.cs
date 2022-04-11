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


        /// <summary>
        /// When a page refreshes a <see cref="WebElement"/> might be in a stale state.
        /// A retry might be required.
        /// Interacting with an element may not be enough.
        /// You also might need to provide a selector.
        /// </summary>
        public static void Try(this IWebElement? element, Action<IWebElement?> action, int maxTries = TestsSetup.Config.MaxTries)
            => StaleElementAccessor.Try(() => element, action, maxTries);

        /// <summary>
        /// When a page refreshes a <see cref="WebElement"/> might be in a stale state.
        /// A retry might be required.
        /// Interacting with an element may not be enough.
        /// You also might need to provide a selector.
        /// </summary>
        public static IWebElement? TryFind(this IWebElement? element, Func<IWebElement?, IWebElement?> selector, int maxTries = TestsSetup.Config.MaxTries)
            => StaleElementAccessor.TryFind(() => element, selector, maxTries);

    }
}
