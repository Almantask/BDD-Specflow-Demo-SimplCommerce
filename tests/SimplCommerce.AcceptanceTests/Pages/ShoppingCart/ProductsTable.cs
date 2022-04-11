using OpenQA.Selenium;
using SimplCommerce.AcceptanceTests.Extensions;
using SimplCommerce.AcceptanceTests.HtmlElements;
using SimplCommerce.AcceptanceTests.Utils;

namespace SimplCommerce.AcceptanceTests.Pages.ShoppingCart
{
    public class ProductsTable
    {
        private readonly HtmlTable _table;

        public ProductsTable(HtmlTable table)
        {
            _table = table;
        }

        public Product FindProduct(string product)
        {
            var productElement = FindProductWebElement(product);

            return Product.FromWebElement(productElement);
        }

        public IWebElement? FindProductWebElement(string product)
        {
            // Contains name, because the name also has extras such as size (S/M/L/..) and color (Silver, Bronze...)
            // https://stackoverflow.com/questions/3655549/xpath-containstext-some-string-doesnt-work-when-used-with-node-with-more
            // http://xpather.com/uM2nm4x2 - surprisingly, http but the only playground for xpath that works with html.

            var productElement = StaleElementAccessor.TryFind(
                () =>
                {
                    _table.Body.TryFindElement(By.XPath($"./tr/td[2]//h6[contains(text(),'{product}')]"), out var result);
                    // make sure we can interact with it
                    result?.Click();

                    return result;
                },
                (header) => header?.GetParent()?.GetParent());

            return productElement;
        }
    }
}
