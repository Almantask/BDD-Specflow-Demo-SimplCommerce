using OpenQA.Selenium;
using SimplCommerce.AcceptanceTests.Extensions;

namespace SimplCommerce.AcceptanceTests.HtmlElements
{
    /// <summary>
    /// A wrapper around html table/body.
    /// </summary>
    public class HtmlTable
    {
        public IWebElement Body { get; }

        /// <summary>
        /// Initialize table from a wrapping element.
        /// </summary>
        public static HtmlTable FromWrapperElement(IWebElement wrapperElement)
        {
            var body = wrapperElement.FindElement(By.XPath(@"./table/tbody"));
            return new HtmlTable(body);
        }

        /// <summary>
        /// Initialize table from table element
        /// </summary>
        public static HtmlTable FromTableElement(IWebElement tableElement)
        {
            var body = tableElement.FindElement(By.XPath(@"./tbody"));
            return new HtmlTable(body);
        }

        /// <summary>
        /// Initializes accessor around table/body.
        /// </summary>
        private HtmlTable(IWebElement body)
        {
            Body = body;
        }

        /// <summary>
        /// Gets value of element at the table and converts it to specified generic type.
        /// Selection is done based on tr and td xpath.
        /// As in HTML, first row/column starts at 1.
        /// </summary>
        /// <typeparam name="T">Type to which to convert element value.</typeparam>
        /// <param name="row">tr of html table.</param>
        /// <param name="column">td of html table.</param>
        /// <param name="sanitize">Function applied during value extraction.</param>
        /// <returns></returns>
        public T? GetValueAt<T>(int row, int column, Func<string, string>? sanitize = null)
        {
            var element = GetElementAt(row, column);
            return element.Text.ConvertTo<T>(sanitize);
        }

        /// <summary>
        /// Gets element at the table.
        /// Selection is done based on tr and td xpath.
        /// As in HTML, first row/column starts at 1.
        /// </summary>
        /// <param name="row">tr of html table.</param>
        /// <param name="column">td of html table.</param>
        /// <returns></returns>
        public IWebElement GetElementAt(int row, int column)
            => Body.FindElement(By.XPath($"tr[{row}]/td[{column}]"));
    }
}
