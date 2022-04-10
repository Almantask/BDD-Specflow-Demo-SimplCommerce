﻿using NUnit.Framework;
using OpenQA.Selenium;

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
        /// When a page refreshes a WebElement might be in a stale state.
        /// A retry might be required.
        /// </summary>
        /// <returns></returns>
        public static IWebElement? TryClicking(this IWebElement? element, int maxTries)
        {
            while (maxTries > 0)
            {
                try
                {
                    element?.Click();
                }
                catch (StaleElementReferenceException)
                {
                    maxTries--;
                }
            }

            if (maxTries == 0)
            {
                Assert.Fail($"Failed to click {element?.Text}");
            }

            return element;
        }
    }
}
