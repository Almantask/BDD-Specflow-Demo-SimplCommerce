using OpenQA.Selenium;
using SimplCommerce.AcceptanceTests.Extensions;
using SimplCommerce.AcceptanceTests.HtmlElements;

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
            // /html/body/div[4]/div/div[1]/table
            // /html/body/div[4]/div/div[1]/table/tbody/tr[1]/td[2]/h6
            // https://stackoverflow.com/questions/3655549/xpath-containstext-some-string-doesnt-work-when-used-with-node-with-more
            // http://xpather.com/uM2nm4x2 - surprisingly, http but the only one that works with html.
            _table.Body.TryFindElement(
                By.XPath($"./tr/td[2]/h6//text()[contains(.,'{product}')]"),
                out var productHeader);
            // parent(td), parent(tr)
            var productElement = productHeader?.GetParent()?.GetParent();

            return productElement;
        }
    }
}
