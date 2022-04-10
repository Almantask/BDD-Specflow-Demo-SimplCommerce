using SimplCommerce.AcceptanceTests.Extensions;
using SimplCommerce.AcceptanceTests.HtmlElements;

namespace SimplCommerce.AcceptanceTests.Pages.ShoppingCart;

public record OrderSummary(decimal Subtotal, decimal Discount, decimal OrderTotal)
{
    public static OrderSummary FromHtmlTable(HtmlTable table)
    {
        var subtotal = GetMoneyAtRow(1);
        var discount = GetMoneyAtRow(2);
        var orderTotal = GetMoneyAtRow(3);
        var orderSummary = new OrderSummary(subtotal, discount, orderTotal);

        return orderSummary;

        decimal GetMoneyAtRow(int row)
        {
            const int priceColumn = 2;
            return table.GetValueAt<decimal>(row, priceColumn, InputSanitizers.Money);
        }
    }
}
