using OpenQA.Selenium;
using SimplCommerce.FunctionalTests.Pages;

namespace SimplCommerce.FunctionalTests.Steps.ShoppingCart
{
    [Binding]
    public class ShoppingCartProductsSteps
    {
        private readonly NavigationBar _navigationBar;
        private const string ExpectedOnlyProduct = "Square Neck Back";

        public ShoppingCartProductsSteps(IWebDriver driver)
        {
            _navigationBar = new NavigationBar(driver);
        }

        [Given(@"Shopping cart contains a product")]
        public void GivenAusraHasASingleProductInTheShoppingCart()
        {
            var quantity = _navigationBar
                .NavigateToShoppingCart()
                .GetProductQuantity(ExpectedOnlyProduct);
            if (quantity >= 1) return;

            _navigationBar
                .NavigateToHomePage()
                .NavigateToProductPage(ExpectedOnlyProduct)
                .AddToCart()
                .CloseProductAddedToCartModal();

            _navigationBar.NavigateToShoppingCart();
        }
    }
}
