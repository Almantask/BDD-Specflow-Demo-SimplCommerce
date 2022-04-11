using OpenQA.Selenium;
using SimplCommerce.AcceptanceTests.Extensions;
using SimplCommerce.AcceptanceTests.Utils;

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

        public ShoppingCartPage DecrementQuantity(string productName)
        {
            ClickButtonOnAProduct(productName, "-");
            return this;
        }

        public ShoppingCartPage IncrementQuantity(string productName)
        {
            ClickButtonOnAProduct(productName, "+");
            return this;
        }

        public ShoppingCartPage SetProductQuantityTo(string productName, string quantity)
        {
            var product = FindProductWebElement(productName);
            var productQuantity = FindProductQuantityElement(product);
            productQuantity?.SendKeys(quantity);

            return this;
        }

        public ShoppingCartPage SetProductQuantityTo(string productName, int quantity)
        {
            var productWebElement = FindProductWebElement(productName);
            var product = Product.FromWebElement(productWebElement);

            var difference = quantity - product.Quantity;
            if (difference > 0)
            {
                for (int i = 0; i < difference; i++)
                {
                    var incrementQuantityButton = FindButtonOnAProduct(productWebElement, "+");
                    incrementQuantityButton.Try(e => e.Click());
                }
            }
            else
            {
                for (int i = difference; i < 0; i++)
                {
                    var decrementQuantityButton = FindButtonOnAProduct(productWebElement, "-");
                    decrementQuantityButton.Try(e => e.Click());
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

        private IWebElement FindProductWebElement(string productName)
        {
            var productsHtmlTable = Driver.FindTableUsingBody(By.CssSelector(".table.table-striped.cart-items"));
            var productsTable = new ProductsTable(productsHtmlTable);

            return productsTable.FindProductWebElement(productName);
        }

        private IWebElement FindButtonOnAProduct(string productName, string text)
        {
            var product = FindProductWebElement(productName);
            return product.FindElement(By.XPath($"//button[text()='{text}']"));
        }

        private IWebElement FindButtonOnAProduct(IWebElement productWebElement, string text)
        {
            return productWebElement.FindElement(By.XPath($"//button[text()='{text}']"));
        }

        private IWebElement? FindProductQuantityElement(IWebElement? productElement)
            => productElement?.FindElement(
                By.CssSelector(".quantity-field.ng-pristine.ng-untouched.ng-valid.ng-not-empty"));

        private void ClickButtonOnAProduct(string productName, string button)
        {
            StaleElementAccessor.Try(
                () => FindButtonOnAProduct(productName, button),
                decrementQuantityButton => decrementQuantityButton.Click()
            );
        }
    }
}
