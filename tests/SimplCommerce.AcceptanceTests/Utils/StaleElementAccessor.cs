using NUnit.Framework;
using OpenQA.Selenium;

namespace SimplCommerce.AcceptanceTests.Utils
{
    /// <summary>
    /// A retry might be required.
    /// Interacting with an element may not be enough.
    /// </summary>
    public static class StaleElementAccessor
    {
        /// <summary>
        /// Try getting an element and then interacting with it.
        /// </summary>
        /// <returns>The same element that was found.</returns>
        public static void Try(
            Func<IWebElement> findElement,
            Action<IWebElement?> action,
            int maxTries = TestsSetup.Config.MaxRetries)
        {
            // Find and interact.
            TryFind(findElement,
                (element) =>
                {
                    action(element);
                    return element;
                },
                maxTries);
        }

        /// <summary>
        /// Try getting an element and then selecting something from it.
        /// </summary>
        /// <returns>Element after selector is applied to it.</returns>
        public static IWebElement TryFind(
            Func<IWebElement> findElement,
            Func<IWebElement?, IWebElement> selector,
            int maxTries = TestsSetup.Config.MaxRetries)
        {
            while (maxTries > 0)
            {
                try
                {
                    var element = findElement();
                    return selector(element);
                }
                catch (StaleElementReferenceException ex)
                {
                    maxTries--;
                }
            }

            if (maxTries == 0)
            {
                Assert.Fail($"Failed to interact with WebElement.");
            }

            // Should never go here.
            return null;
        }
    }
}
