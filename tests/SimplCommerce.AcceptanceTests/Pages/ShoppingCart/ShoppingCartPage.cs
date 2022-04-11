using SimplCommerce.AcceptanceTests.Extensions;
using SimplCommerce.AcceptanceTests.Utils;

namespace SimplCommerce.AcceptanceTests.Pages.ShoppingCart
{
    public class ShoppingCartPage : BasePage
    {
        private static class Buttons
        {
            public const string Increment = "+";
            public const string Decrement = "-";
        }

        private const string Url = "cart";

        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }

        public ShoppingCartPage NavigateTo()
        {
            NavigateTo(Url);
            return this;
        }

        public int GetProductQuantity(string productName)
            => StaleElementAccessor.TryFind(() => FindProductWebElement(productName), ProductWebElement.FindQuantity);

        public decimal GetProductPrice(string productName)
            => StaleElementAccessor.TryFind(() => FindProductWebElement(productName), ProductWebElement.FindPrice);

        public ShoppingCartPage DecrementQuantity(string productName)
        {
            ClickButtonOnAProduct(productName, Buttons.Decrement);
            return this;
        }

        public ShoppingCartPage IncrementQuantity(string productName)
        {
            ClickButtonOnAProduct(productName, Buttons.Increment);
            return this;
        }

        public ShoppingCartPage SetProductQuantityTo(string productName, string quantity)
        {
            StaleElementAccessor.Try(
                () =>
                {
                    var product = FindProductWebElement(productName);
                    var productQuantityTextBox = ProductWebElement.FindQuantityTextBox(product!);
                    return productQuantityTextBox;
                }, (productQuantityTextBox) => productQuantityTextBox?.SendKeys(quantity));

            return this;
        }

        public ShoppingCartPage SetProductQuantityTo(string productName, int quantity)
        {
            var difference = quantity - GetProductQuantity(productName);
            if (difference > 0)
            {
                for (int i = 0; i < difference; i++)
                {

                    ClickButtonOnAProduct(productName, Buttons.Increment);
                }
            }
            else
            {
                for (int i = difference; i < 0; i++)
                {
                    ClickButtonOnAProduct(productName, Buttons.Decrement);
                }
            }

            return this;
        }

        public OrderSummary GetOrderSummary()
        {
            var table = Driver.FindTable(By.CssSelector(".order-summary.ng-scope"));
            return OrderSummary.FromHtmlTable(table);
        }

        private void ClickButtonOnAProduct(string productName, string button)
        {
            StaleElementAccessor.Try(
                () => FindButtonOnAProduct(productName, button),
                changeQuantityBy1Button => changeQuantityBy1Button!.Click()
            );
        }

        private IWebElement FindButtonOnAProduct(string productName, string button)
        {
            var product = FindProductWebElement(productName);
            return ProductWebElement.FindButton(product!, button);
        }

        private IWebElement? FindProductWebElement(string productName)
            => Driver.FindElementOrDefault(
                By.CssSelector(".table.table-striped.cart-items"),
                By.XPath($"./tbody/tr/td[2]//h6[contains(text(),'{productName}')]/../.."));
    }
}
