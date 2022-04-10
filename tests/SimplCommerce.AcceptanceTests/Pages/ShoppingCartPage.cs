using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SimplCommerce.AcceptanceTests.Extensions;

namespace SimplCommerce.AcceptanceTests.Pages
{
    public class ShoppingCartPage : BasePage
    {
        private const string Url = "https://localhost:44388/cart";

        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }

        public ShoppingCartPage NavigateTo()
        {
            Driver.Navigate().GoToUrl(Url);
            return this;
        }

        public int GetProductQuantity(string productName)
        {
            var productElement = FindProduct(productName);
            return FindProductQuantity(productElement);
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

        public ShoppingCartPage SetProductQuantityTo(string name, string quantity)
        {
            var product = FindProduct(name);
            var productQuantity = FindProductQuantityElement(product);

            productQuantity?.SendKeys(quantity);

            return this;
        }

        public ShoppingCartPage SetProductQuantityTo(string name, int quantity)
        {
            var product = FindProduct(name);
            var currentQuantity = FindProductQuantity(product);

            var difference = quantity - currentQuantity;
            // Quantity cannot be set directly due to how model binding works for angular.
            // It does not update if quantity through html is updated.
            // Need to update model binding.
            const int maxClickRetries = 5;
            if (difference > 0)
            {
                for (int i = 0; i < difference; i++)
                {
                    // In a loop, because after a click page refreshes.
                    var incrementQuantityButton = FindButton("+");
                    incrementQuantityButton.TryClicking(maxClickRetries);
                }
            }
            else
            {
                for (int i = difference; i < 0; i++)
                {
                    // In a loop, because after a click page refreshes.
                    var decrementQuantityButton = FindButton("-");
                    decrementQuantityButton.TryClicking(maxClickRetries);
                }
            }

            return this;
        }

        public OrderSummary GetOrderSummary()
        {
            var table = Driver.FindTable(By.CssSelector(".order-summary.ng-scope"));
            var subtotal = table.GetValueOfElementAt<decimal>(1, 2);
            var discount = table.GetValueOfElementAt<decimal>(2, 2);
            var orderTotal = table.GetValueOfElementAt<decimal>(3, 2);
            var orderSummary = new OrderSummary(subtotal, discount, orderTotal);

            return orderSummary;
        }

        public decimal GetProductPrice(string expectedOnlyProduct)
        {
            throw new NotImplementedException();
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
            var quantityElement = FindProductQuantityElement(productElement);
            var quantityValue = quantityElement?.GetAttribute("value");

            return string.IsNullOrWhiteSpace(quantityValue) ? 0 : int.Parse(quantityValue);
        }

        private IWebElement FindButton(string text)
        {
            // In order to prevent Stale Element Reference Exception.
            var waitDriver = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(500));
            // This doesn't seem to help
            var button = waitDriver.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.XPath($"//button[text()='{text}']")));

            return button;
        }

        private IWebElement? FindProductQuantityElement(IWebElement? productElement)
            => productElement?.FindElement(
                By.CssSelector(".quantity-field.ng-pristine.ng-untouched.ng-valid.ng-not-empty"));

        public record OrderSummary(decimal Subtotal, decimal Discount, decimal OrderTotal);
    }
}
