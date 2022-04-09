using NUnit.Framework;
using OpenQA.Selenium;
using SimplCommerce.FunctionalTests.Extensions;

namespace SimplCommerce.FunctionalTests.Pages
{
    public class ShoppingCartPage : BasePage
    {
        private const string Url = "https://localhost:44388/cart";

        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }

        public int GetProductQuantity(string productName)
        {
            var productElement = FindProduct(productName);
            return FindProductQuantity(productElement);
        }

        public ShoppingCartPage NavigateTo()
        {
            Driver.Navigate().GoToUrl(Url);
            return this;
        }

        private IWebElement? FindProduct(string name)
        {
            var itemHeaders = Driver.FindElements(By.TagName("h6"));
            // Contains name, because the name also has extras such as size (S/M/L/..) and color (Silver, Bronze...)
            var itemHeader = itemHeaders.FirstOrDefault(ih => ih.Text.Contains(name));
            // parent(td), parent(tr)
            var itemLine = itemHeader?.GetParent().GetParent();

            return itemLine;
        }

        private int FindProductQuantity(IWebElement? productElement)
        {
            var quantityElement = productElement?.FindElement(
                    By.CssSelector(".quantity-field.ng-pristine.ng-untouched.ng-valid.ng-not-empty"));
            var quantityValue = quantityElement?.GetAttribute("value");

            return string.IsNullOrWhiteSpace(quantityValue) ? 0 : int.Parse(quantityValue);
        }

        public ShoppingCartPage DecrementQuantity(string expectedOnlyProduct)
        {
            var decrementQuantityButton = FindButton("-");
            decrementQuantityButton.Click();
            return this;
        }

        public ShoppingCartPage IncrementQuantity(string expectedOnlyProduct)
        {
            var incrementQuantityButton = FindButton("+");
            incrementQuantityButton.Click();
            return this;
        }

        private IWebElement FindButton(string text)
            => Driver.FindElement(By.XPath($"//button[text()='{text}']"));

        public ShoppingCartPage SetProductQuantityTo(string item, int quantity)
        {
            var product = FindProduct(item);
            var currentQuantity = FindProductQuantity(product);

            var difference = quantity - currentQuantity;
            // Quantity cannot be set directly due to how model binding works for angular.
            // It does not update if quantity through html is updated.
            // Need to update model binding.
            if (difference > 0)
            {
                for (int i = 0; i < difference; i++)
                {
                    // In a loop, because after a click page refreshes.
                    var incrementQuantityButton = FindButton("+");
                    incrementQuantityButton.Click();
                }
            }
            else
            {
                for (int i = difference; i < 0; i++)
                {
                    // In a loop, because after a click page refreshes.
                    var decrementQuantityButton = FindButton("-");
                    decrementQuantityButton.Click();
                }
            }

            return this;
        }


    }
}
