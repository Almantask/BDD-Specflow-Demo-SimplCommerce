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

        public int Count(string item)
        {
            var itemElement = FindItem(item);
            var quantityElement = itemElement?.FindElement(By.ClassName("quantity-field ng-pristine ng-untouched ng-valid ng-not-empty"));
            var quantityValue = quantityElement?.GetAttribute("value");
            if (string.IsNullOrWhiteSpace(quantityValue))
            {
                return 0;
            }

            return int.Parse(quantityValue);
        }

        public ShoppingCartPage NavigateTo()
        {
            Driver.Navigate().GoToUrl(Url);
            return this;
        }

        private IWebElement? FindItem(string name)
        {
            const string itemNameTag = "h6";
            var itemHeaders = Driver.FindElements(By.TagName(itemNameTag));
            var itemHeader = itemHeaders.FirstOrDefault(ih => ih.Text == name);
            // parent(td), parent(tr)
            var itemLine = itemHeader?.GetParent().GetParent();

            return itemLine;
        }
    }
}
