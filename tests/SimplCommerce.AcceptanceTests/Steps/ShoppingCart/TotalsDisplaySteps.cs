using OpenQA.Selenium;
using SimplCommerce.AcceptanceTests.Pages;
using static SimplCommerce.AcceptanceTests.Steps.ShoppingCart.ShoppingCartTestContext;

namespace SimplCommerce.AcceptanceTests.Steps.ShoppingCart
{
    [Binding]
    public class TotalsDisplaySteps
    {
        private const string OrderSummaryTag = "OrderSummary";

        private readonly ScenarioContext _context;
        private readonly ShoppingCartPage _page;

        private ShoppingCartPage.OrderSummary? _initialOrderSummary;

        public TotalsDisplaySteps(IWebDriver driver, ScenarioContext context)
        {
            _page = new ShoppingCartPage(driver);
            _context = context;
        }

        [Then(@"shopping cart display Subtotal and Order Total should be updated")]
        public void ThenShoppingCartDisplaySubtotalAndOrderTotalShouldBeUpdated()
        {
            var currentOrderSummary = _page.GetOrderSummary();

            currentOrderSummary.Discount.Should().Be(_initialOrderSummary.Discount);

            var initialProductQuantity = _context.GetInitialProductQuantity();
            var currentProductQuantity = _page.GetProductQuantity(ExpectedOnlyProduct);
            var quantityDifference = currentProductQuantity - initialProductQuantity;

            var productPrice = _page.GetProductPrice(ExpectedOnlyProduct);
            var productTotalPriceDifference = productPrice * quantityDifference;
            var expectedSubTotal = _initialOrderSummary.Subtotal + productTotalPriceDifference;
            var expectedOrderTotal = _initialOrderSummary.OrderTotal + productTotalPriceDifference;

            currentOrderSummary.Subtotal.Should().NotBe(expectedSubTotal);
            currentOrderSummary.OrderTotal.Should().NotBe(expectedOrderTotal);
        }

        [BeforeScenario(OrderSummaryTag)]
        public void SetInitialOrderSummary()
        {
            _initialOrderSummary = _page.GetOrderSummary();
        }
    }
}
