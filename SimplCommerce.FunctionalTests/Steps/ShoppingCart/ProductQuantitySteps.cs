using OpenQA.Selenium;
using SimplCommerce.FunctionalTests.Pages;
using static SimplCommerce.FunctionalTests.Steps.ShoppingCart.ShoppingCartTestContext;

namespace SimplCommerce.FunctionalTests.Steps.ShoppingCart
{
    [Binding]
    public class ProductQuantitySteps
    {
        private readonly ShoppingCartPage _shoppingCartPage;

        public ProductQuantitySteps(IWebDriver webDriver)
        {
            _shoppingCartPage = new ShoppingCartPage(webDriver);
            _shoppingCartPage.NavigateTo();
        }

        [When(@"Ausra decrements product quantity")]
        public void WhenAusraDecrementsProductQuantity()
        {
            _shoppingCartPage.DecrementQuantity(ExpectedOnlyProduct);
        }

        [Given(@"product quantity is at least ([0-9]+)")]
        [Given(@"product quantity is ([0-9]+)")]
        public void GivenProductQuantityIs(int quantity)
        {
            _shoppingCartPage.SetProductQuantityTo(ExpectedOnlyProduct, quantity);
        }

        [When(@"Ausra increments product quantity")]
        public void WhenAusraIncrementsProductQuantity()
        {
            _shoppingCartPage.IncrementQuantity(ExpectedOnlyProduct);
        }

        [When(@"Ausra sets product quantity to (.*)")]
        public void WhenAusraSetsProductQuantityTo(int p0)
        {

        }

        [When(@"Ausra sets product quantity")]
        public void WhenAusraSetsProductQuantity()
        {

        }

        [Then(@"product quantity should be decremented")]
        public void ThenProductQuantityShouldBeDecremented()
        {
            throw new PendingStepException();
        }

        [Then(@"product quantity should be unchanged")]
        public void ThenProductQuantityShouldBeUnchanged()
        {
            throw new PendingStepException();
        }

        [Then(@"product quantity should be incremented")]
        public void ThenProductQuantityShouldBeIncremented()
        {
            throw new PendingStepException();
        }
    }
}
