using OpenQA.Selenium;

namespace SimplCommerce.FunctionalTests.Pages
{
    public class ShoppingCartPage : BasePage
    {
        private const string BaseUrl = "https://localhost:44388/woman";

        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }

        public int Count(string item)
        {
            // count item;
            return 0;
        }

        public ShoppingCartPage NavigateTo()
        {
            Driver.Navigate().GoToUrl("todo");
        }
    }
}
