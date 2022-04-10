using OpenQA.Selenium;
using SimplCommerce.AcceptanceTests.Pages;
using static SimplCommerce.AcceptanceTests.Steps.ShoppingCart.ShoppingCartTestContext;

// Not an issue, the variable is set in the hook [BeforeScenario].
// It is run before the other steps.
#pragma warning disable CS8618

namespace SimplCommerce.AcceptanceTests.Steps.ShoppingCart
{
    [Binding]
    public class TotalsDisplaySteps
    {
        private const string OrderSummaryTag = "OrderSummary";

        private readonly ScenarioContext _context;
        private readonly ShoppingCartPage _page;

        private ShoppingCartPage.OrderSummary _initialOrderSummary;

        public TotalsDisplaySteps(IWebDriver driver, ScenarioContext context)
        {
            _page = new ShoppingCartPage(driver);
            _context = context;
        }

        [Then(@"shopping cart display Subtotal and Order Total should be updated")]
        public void ThenShoppingCartDisplaySubtotalAndOrderTotalShouldBeUpdated()
        {
            var productTotalPriceDifference = GetTotalPriceDifference();
            var expectedSubTotal = _initialOrderSummary.Subtotal + productTotalPriceDifference;
            var expectedOrderTotal = _initialOrderSummary.OrderTotal + productTotalPriceDifference;

            var expectedOrderSummary = new ShoppingCartPage.OrderSummary(expectedSubTotal, _initialOrderSummary.Discount, expectedOrderTotal);
            var currentOrderSummary = _page.GetOrderSummary();
            currentOrderSummary.Should().BeEquivalentTo(expectedOrderSummary);
        }

        [BeforeScenario(OrderSummaryTag)]
        public void SetInitialOrderSummary()
        {
            _initialOrderSummary = _page.GetOrderSummary();
        }

        private decimal GetTotalPriceDifference()
        {
            var initialProductQuantity = _context.GetInitialProductQuantity();
            var currentProductQuantity = _page.GetProductQuantity(ExpectedOnlyProduct);
            var quantityDifference = currentProductQuantity - initialProductQuantity;

            var productPrice = _page.GetProductPrice(ExpectedOnlyProduct);

            return productPrice * quantityDifference;
        }
    }
}
