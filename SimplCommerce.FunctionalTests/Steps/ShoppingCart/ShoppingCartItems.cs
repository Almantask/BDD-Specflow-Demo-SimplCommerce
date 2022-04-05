﻿using OpenQA.Selenium;
using SimplCommerce.FunctionalTests.Pages;

namespace SimplCommerce.FunctionalTests.Steps.ShoppingCart
{
    public class ShoppingCartItems
    {
        private readonly NavigationBar _navigationBar;
        private const string ExpectedOnlyItem = "Test";

        public ShoppingCartItems(IWebDriver driver)
        {
            _navigationBar = new NavigationBar(driver);
        }

        [Given(@"Ausra's Shopping cart contains an item")]
        public void GivenAusraHasASingleItemInTheShoppingCart()
        {
            var count = _navigationBar
                .NavigateToShoppingCart()
                .Count(ExpectedOnlyItem);
            if (count == 1) return;

            _navigationBar
                .NavigateToHomePage()
                .NavigateToItemPage(ExpectedOnlyItem)
                .AddToCart();

            _navigationBar.NavigateToShoppingCart();
        }

    }
}
