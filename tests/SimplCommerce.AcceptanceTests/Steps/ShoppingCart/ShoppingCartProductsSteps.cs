using OpenQA.Selenium;
using SimplCommerce.AcceptanceTests.Pages;
using static SimplCommerce.AcceptanceTests.Steps.ShoppingCart.ShoppingCartTestContext;

namespace SimplCommerce.AcceptanceTests.Steps.ShoppingCart
{
    [Binding]
    public class ShoppingCartProductsSteps
    {
        private ScenarioContext _context;
        private readonly NavigationBar _navigationBar;

        public ShoppingCartProductsSteps(IWebDriver driver, ScenarioContext context)
        {
            _navigationBar = new NavigationBar(driver);
            _context = context;
        }

        [Given(@"Shopping cart contains a product")]
        public void GivenAusraHasASingleProductInTheShoppingCart()
        {
            var quantity = _navigationBar
                .NavigateToShoppingCart()
                .GetProductQuantity(ExpectedOnlyProduct);

            if (quantity < 1)
            {
                _navigationBar
                    .NavigateToHomePage()
                    .NavigateToProductPage(ExpectedOnlyProduct)
                    .AddToCart()
                    .CloseProductAddedToCartModal();

                quantity = 1;

                _navigationBar.NavigateToShoppingCart();
            }

            _context.SetInitialProductQuantity(quantity);
        }
    }
}
