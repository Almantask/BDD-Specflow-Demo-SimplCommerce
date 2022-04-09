﻿using NUnit.Framework;
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
            ProductQuantityShouldBe((original, current) => current < original);
        }

        [Then(@"product quantity should be unchanged")]
        public void ThenProductQuantityShouldBeUnchanged()
        {
            ProductQuantityShouldBe((original, current) => current == original);
        }

        [Then(@"product quantity should be incremented")]
        public void ThenProductQuantityShouldBeIncremented()
        {
            ProductQuantityShouldBe((original, current) => current > original);
        }

        /// <summary>
        /// Verifies that original product quantity compared to original meets specified condition.
        /// </summary>
        /// <param name="condition">original, current</param>
        private void ProductQuantityShouldBe(Func<int, int, bool> condition)
        {
            var originalQuantity = 0;
            var currentQuantity = 0;
            var isConditionMet = condition(originalQuantity, currentQuantity);
            Assert.True(isConditionMet, $"Failed item quantity expectations.{Environment.NewLine}" +
                                        $"Original: {originalQuantity} Current: {currentQuantity}.");
        }
    }
}
