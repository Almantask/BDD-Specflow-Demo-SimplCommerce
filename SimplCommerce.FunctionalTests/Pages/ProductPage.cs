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
        // Compound class names aren't supported.
        // Use CssSelector instead of class selector.
        // Make sure it starts with "." and classes are separate with ".".
        var addToCartButton = Driver.FindElements(By.CssSelector(".btn.btn-lg.btn-add-cart"));
        addToCartButton?.FirstOrDefault()?.Click();
        return this;
    }

    public ProductPage CloseProductAddedToCartModal()
    {
        var closeButton = Driver.FindElement(By.ClassName("close"));
        closeButton.Click();

        return this;
    }
}
