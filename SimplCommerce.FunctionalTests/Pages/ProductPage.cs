using OpenQA.Selenium;

namespace SimplCommerce.FunctionalTests.Pages;

public class ProductPage : BasePage
{
    protected string Url { get; }

    public ProductPage(IWebDriver driver, string product) : base(driver)
    {
        var sanitizedProduct = product.Replace(" ", "-").ToLower();
        Url = $@"https://localhost:44388/{sanitizedProduct}";
    }

    public ProductPage NavigateTo()
    {
        Driver.Navigate().GoToUrl(Url);
        return this;
    }

    public ProductPage AddToCart()
    {
        return this;
    }
}
