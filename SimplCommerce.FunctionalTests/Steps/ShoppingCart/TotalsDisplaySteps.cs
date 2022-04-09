using OpenQA.Selenium;
using SimplCommerce.FunctionalTests.Pages;
using static SimplCommerce.FunctionalTests.Steps.ShoppingCart.ShoppingCartTestContext;

namespace SimplCommerce.FunctionalTests.Steps.ShoppingCart
{
    [Binding]
    public class TotalsDisplaySteps
    {
        private const string OrderSummaryTag = "OrderSummary";

        private readonly ScenarioContext _context;
        private readonly ShoppingCartPage _page;

        private decimal _initialSubtotal;
        private decimal _initialDiscount;
        private decimal _initialOrderTotal;

        public TotalsDisplaySteps(IWebDriver driver, ScenarioContext context)
        {
            _page = new ShoppingCartPage(driver);
            _context = context;
        }

        [Then(@"shopping cart display Subtotal and Order Total should be updated")]
        public void ThenShoppingCartDisplaySubtotalAndOrderTotalShouldBeUpdated()
        {
            var currentSubtotal = _page.GetSubtotal();
            var currentDiscount = _page.GetDiscount();
            var currentOrderTotal = _page.GetOrderTotal();

            currentDiscount.Should().Be(_initialDiscount);

            var initialProductQuantity = _context.GetInitialProductQuantity();
            var currentProductQuantity = _page.GetProductQuantity(ExpectedOnlyProduct);
            var quantityDifference = currentProductQuantity - initialProductQuantity;

            var productPrice = _page.GetProductPrice(ExpectedOnlyProduct);
            var productTotalPriceDifference = productPrice * quantityDifference;
            var expectedSubTotal = _initialSubtotal + productTotalPriceDifference;
            var expectedOrderTotal = _initialOrderTotal + productTotalPriceDifference;

            currentSubtotal.Should().NotBe(expectedSubTotal);
            currentOrderTotal.Should().NotBe(expectedOrderTotal);
        }

        [BeforeScenario(OrderSummaryTag)]
        public void SetInitialOrderSummary()
        {
            _initialSubtotal = _page.GetSubtotal();
            _initialDiscount = _page.GetDiscount();
            _initialOrderTotal = _page.GetOrderTotal();
        }
    }
}
