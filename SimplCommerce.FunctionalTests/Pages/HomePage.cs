using OpenQA.Selenium;

namespace SimplCommerce.FunctionalTests.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public HomePage NavigateTo()
        {
            Driver.Navigate().GoToUrl("todo");
            return this;
        }

        public ItemPage NavigateToItemPage(string item)
        {
            return new ItemPage(Driver);
        }
    }
}
