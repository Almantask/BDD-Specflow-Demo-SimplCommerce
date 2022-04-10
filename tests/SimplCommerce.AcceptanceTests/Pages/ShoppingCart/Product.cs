using OpenQA.Selenium;
using SimplCommerce.AcceptanceTests.Extensions;

namespace SimplCommerce.AcceptanceTests.Pages.ShoppingCart;

public record Product(string? Name, decimal Price, short Quantity)
{
    public static Product FromWebElement(IWebElement? productElement)
    {
        if (productElement == null) return NotFound();

        var name = FindValueByXpath<string>("./td[2]/h6");
        var price = FindValueByXpath<decimal>("./td[3]", InputSanitizers.Money);
        var quantity = FindValueByXpath<short>(".td[4]/input");

        return new Product(name, price, quantity);

        T FindValueByXpath<T>(string xpath, Func<string, string>? sanitize = null)
        {
            var text = productElement.FindElement(By.XPath(xpath)).Text;
            return text.ConvertTo<T>(sanitize);
        }
    }

    public static Product NotFound()
        => new Product(default, default, default);
}
