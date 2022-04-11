﻿using SimplCommerce.AcceptanceTests.Pages.ShoppingCart;
using static SimplCommerce.AcceptanceTests.Steps.ShoppingCart.ShoppingCartTestContext;
using static SimplCommerce.AcceptanceTests.TestsSetup;

namespace SimplCommerce.AcceptanceTests.Steps.ShoppingCart
{
    [Binding]
    public class ProductQuantitySteps
    {
        private readonly ScenarioContext _context;
        private readonly ShoppingCartPage _shoppingCartPage;

        public ProductQuantitySteps(ScenarioContext context)
        {
            _context = context;
            _shoppingCartPage = new ShoppingCartPage(Driver);
            // Implied that all that is run will run in the context of ShoppingCartPage.
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
        // Arg is string, because the quantity comes as input from keyboard.
        public void WhenAusraSetsProductQuantityTo(string quantity)
        {
            _shoppingCartPage.SetProductQuantityTo(ExpectedOnlyProduct, quantity);
        }

        [When(@"Ausra sets product quantity")]
        public void WhenAusraSetsProductQuantity()
        {
            // An action of setting quantity can be done through:
            // - Increment
            // - Decrement
            // - Editing TextBox
            // Choosing the easiest - increment.
            _shoppingCartPage.IncrementQuantity(ExpectedOnlyProduct);
        }

        [Then(@"product quantity should be decremented")]
        public void ThenProductQuantityShouldBeDecremented()
        {
            ProductQuantityShouldBe((original, current) => current.Should().BeLessThan(original));
        }

        [Then(@"product quantity should be unchanged")]
        public void ThenProductQuantityShouldBeUnchanged()
        {
            ProductQuantityShouldBe((original, current) => current.Should().Be(original));
        }

        [Then(@"product quantity should be incremented")]
        public void ThenProductQuantityShouldBeIncremented()
        {
            ProductQuantityShouldBe((original, current) => current.Should().BeGreaterThan(original));
        }

        /// <summary>
        /// Verifies that original product quantity compared to original meets specified condition.
        /// </summary>
        /// <param name="condition">original, current</param>
        private void ProductQuantityShouldBe(Action<int, int> assertion)
        {
            var originalQuantity = _context.GetInitialProductQuantity();
            var currentQuantity = _shoppingCartPage.GetProductQuantity(ExpectedOnlyProduct);

            assertion(originalQuantity, currentQuantity);
        }

        [AfterStep]
        public void UpdateInitialQuantity()
        {
            if (!_context.StepContext.StepInfo.Text.Contains("product quantity is")) return;

            var quantity = _shoppingCartPage.GetProductQuantity(ExpectedOnlyProduct);
            _context.SetInitialProductQuantity(quantity);
        }
    }
}
