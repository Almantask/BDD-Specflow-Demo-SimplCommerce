namespace SimplCommerce.AcceptanceTests.Utils
{
    /// <summary>
    /// A retry might be required.
    /// Interacting with an element may not be enough.
    /// </summary>
    public static class StaleElementAccessor
    {
        /// <summary>
        /// Keep on trying to get an element (due to page refreshes).
        /// And then interact with it.
        /// </summary>
        public static void Try(
            Func<IWebElement?> findElement,
            Action<IWebElement?> action,
            int maxTries = TestsSetup.Config.MaxTries)
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
        /// Keep on trying to get an element (due to page refreshes).
        /// And then apply a selector to get something inside it.
        /// </summary>
        /// <returns>Element or parts of it after selector is applied to it.</returns>
        public static T? TryFind<T>(
            Func<IWebElement?> findElement,
            Func<IWebElement?, T> selector,
            int maxTries = TestsSetup.Config.MaxTries)
        {
            while (maxTries > 0)
            {
                try
                {
                    var element = findElement();
                    return selector(element);
                }
                catch (StaleElementReferenceException)
                {
                    maxTries--;
                }
            }

            if (maxTries == 0)
            {
                Assert.Fail($"Failed to interact with WebElement.");
            }

            // Should never go here.
            return default;
        }
    }
}
