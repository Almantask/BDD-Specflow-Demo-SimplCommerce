using System.Diagnostics.CodeAnalysis;
using OpenQA.Selenium;
using SimplCommerce.AcceptanceTests.Pages.ShoppingCart;
using static SimplCommerce.AcceptanceTests.Steps.ShoppingCart.ShoppingCartTestContext;
using static SimplCommerce.AcceptanceTests.TestsSetup;

namespace SimplCommerce.AcceptanceTests.Steps.ShoppingCart
{
    [Binding]
    public class TotalsDisplaySteps
    {
        private readonly ScenarioContext _context;
        private readonly ShoppingCartPage _page;

        private OrderSummary _initialOrderSummary;

        [SuppressMessage("Design", "CS8618", Justification = "Initialized in static hook before all tests.")]
        public TotalsDisplaySteps(ScenarioContext context)
        {
            _page = new ShoppingCartPage(Driver);
            _context = context;
        }

        [Then(@"shopping cart display Subtotal and Order Total should be updated")]
        public void ThenShoppingCartDisplaySubtotalAndOrderTotalShouldBeUpdated()
        {
            var productTotalPriceDifference = GetTotalPriceDifference();
            var expectedSubTotal = _initialOrderSummary.Subtotal + productTotalPriceDifference;
            var expectedOrderTotal = _initialOrderSummary.OrderTotal + productTotalPriceDifference;

            var expectedOrderSummary = new OrderSummary(expectedSubTotal, _initialOrderSummary.Discount, expectedOrderTotal);
            var currentOrderSummary = _page.GetOrderSummary();
            currentOrderSummary.Should().BeEquivalentTo(expectedOrderSummary);
        }

        [BeforeStep]
        public void SetInitialOrderSummary()
        {
            if (_context.StepContext.StepInfo.Text != "Ausra sets product quantity") return;

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
