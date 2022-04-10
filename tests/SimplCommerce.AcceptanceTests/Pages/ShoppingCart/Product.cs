using OpenQA.Selenium;
using SimplCommerce.AcceptanceTests.Extensions;

namespace SimplCommerce.AcceptanceTests.Pages.ShoppingCart;

public record Product(string? Name, decimal Price, short Quantity)
{
    public static Product FromWebElement(IWebElement? productElement)
    {
        if (productElement == null) return NotFound();

        var name = productElement
            .FindElement(By.XPath("./td[2]/h6"))
            .Text;

        var price = productElement
            .FindElement(By.XPath("./td[3]"))
            .Text
            .ConvertTo<decimal>(InputSanitizers.Money);

        var quantity = productElement
            .FindElement(By.XPath("./td[4]/input"))
            .GetAttribute("value")
            .ConvertTo<short>();

        return new Product(name, price, quantity);
    }

    public static Product NotFound()
        => new (default, default, default);
}
