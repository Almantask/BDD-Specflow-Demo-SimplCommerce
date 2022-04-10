using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SimplCommerce.AcceptanceTests.Extensions;

namespace SimplCommerce.AcceptanceTests.Pages.ShoppingCart
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
            => FindProduct(productName).Quantity;

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
            var product = FindProductWebElement(name);
            var productQuantity = FindProductQuantityElement(product);
            productQuantity?.SendKeys(quantity);

            return this;
        }

        public ShoppingCartPage SetProductQuantityTo(string name, int quantity)
        {
            var product = FindProduct(name);
            var difference = quantity - product.Quantity;

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
            var table = Driver.FindTableUsingWrapper(By.CssSelector(".order-summary.ng-scope"));
            return OrderSummary.FromHtmlTable(table);
        }

        public decimal GetProductPrice(string productName)
        {
            var product = FindProduct(productName);
            return product.Price;
        }

        private Product FindProduct(string name)
        {
            var productsHtmlTable = Driver.FindTableUsingBody(By.CssSelector(".table.table-striped.cart-items"));
            var productsTable = new ProductsTable(productsHtmlTable);

            return productsTable.FindProduct(name);
        }

        private IWebElement FindProductWebElement(string name)
        {
            var productsHtmlTable = Driver.FindTableUsingBody(By.CssSelector(".table.table-striped.cart-items"));
            var productsTable = new ProductsTable(productsHtmlTable);

            return productsTable.FindProductWebElement(name);
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
    }
}
