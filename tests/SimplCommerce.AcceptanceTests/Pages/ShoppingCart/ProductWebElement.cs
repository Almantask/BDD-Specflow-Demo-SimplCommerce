using OpenQA.Selenium;
using SimplCommerce.AcceptanceTests.Extensions;

namespace SimplCommerce.AcceptanceTests.Pages.ShoppingCart;

// This could have been a model.
// However, the Product line keeps on refreshing and is sometimes not finished loading.
// If accessing one element as a wrapper, then you would get StaleElementReferenceException.
// The intention of static accessors is to combo them each time with getting the productElement itself.
// And use StaleElementAccess for retries.
public static class ProductWebElement
{
    public static decimal FindPrice(IWebElement? productElement)
        => productElement
            ?.FindElement(By.XPath("./td[3]"))
            ?.Text
            ?.ConvertTo<decimal>(InputSanitizers.Money) ?? 0;

    public static short FindQuantity(IWebElement? productElement)
        => productElement
            ?.FindElement(By.XPath("./td[4]/input"))
            ?.GetAttribute("value")
            ?.ConvertTo<short>() ?? 0;

    public static IWebElement FindButton(IWebElement productElement, string button)
        => productElement.FindElement(By.XPath($"//button[text()='{button}']"));

    public static IWebElement FindQuantityTextBox(IWebElement productElement)
        => productElement.FindElement(By.CssSelector(".quantity-field.ng-pristine.ng-untouched.ng-valid.ng-not-empty"));

}
