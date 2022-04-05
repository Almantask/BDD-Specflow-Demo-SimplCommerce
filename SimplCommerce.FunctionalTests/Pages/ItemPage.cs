using OpenQA.Selenium;

namespace SimplCommerce.FunctionalTests.Pages;

public class ItemPage : BasePage
{
    public ItemPage(IWebDriver driver) : base(driver)
    {
    }

    public ItemPage NavigateTo(string Item)
    {
        Driver.Navigate().GoToUrl("todo");
        return this;
    }

    public ItemPage AddToCart()
    {
        return this;
    }
}
