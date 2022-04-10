using OpenQA.Selenium;

namespace SimplCommerce.AcceptanceTests.HtmlElements
{
    /// <summary>
    /// A wrapper around html table/body.
    /// </summary>
    public class HtmlTable
    {
        private readonly IWebElement _body;

        /// <summary>
        /// Initializes accessor around table/body.
        /// </summary>
        /// <param name="tableWrappingElement">Element which is expected to have element with xpath ./table/tbody.</param>
        public HtmlTable(IWebElement tableWrappingElement)
        {
            _body = tableWrappingElement.FindElement(By.XPath(@"./table/tbody"));
        }

        /// <summary>
        /// Gets value of element at the table and converts it to specified generic type.
        /// Selection is done based on tr and td xpath.
        /// As in HTML, first row/column starts at 1.
        /// </summary>
        /// <typeparam name="T">Type to which to convert element value.</typeparam>
        /// <param name="row">tr of html table.</param>
        /// <param name="column">td of html table.</param>
        /// <returns></returns>
        public T GetValueOfElementAt<T>(int row, int column)
        {
            var element = GetElementAt(row, column);
            var value = element.Text;
            return (T)Convert.ChangeType(value, typeof(T));
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
            => _body.FindElement(By.XPath($"tr[{row}]/td[{column}]"));
    }
}
