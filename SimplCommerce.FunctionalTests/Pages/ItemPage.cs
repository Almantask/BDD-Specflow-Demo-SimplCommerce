using OpenQA.Selenium;

namespace SimplCommerce.FunctionalTests.Pages;

public class ItemPage : BasePage
{
    protected string Url { get; }

    public ItemPage(IWebDriver driver, string item) : base(driver)
    {
        var sanitizedItem = item.Replace(" ", "-").ToLower();
        Url = $@"https://localhost:44388/{sanitizedItem}";
    }

    public ItemPage NavigateTo()
    {
        Driver.Navigate().GoToUrl(Url);
        return this;
    }

    public ItemPage AddToCart()
    {
        return this;
    }
}
