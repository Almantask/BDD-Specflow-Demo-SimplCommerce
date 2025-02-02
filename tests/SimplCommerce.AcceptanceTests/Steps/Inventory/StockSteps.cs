﻿using SimplCommerce.AcceptanceTests.Db;
using static SimplCommerce.AcceptanceTests.Steps.ShoppingCart.TestContext;

namespace SimplCommerce.AcceptanceTests.Steps.Inventory
{
    [Binding]
    public class StockSteps
    {
        private const string StockModifiedTestsTag = "Stock";

        private readonly ScenarioContext _context;
        private int _initialProductQuantity;

        public StockSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Scope(Tag = ShoppingCartTestTag)]
        [Given(@"not enough products in stock")]
        public void GivenNotEnoughProductsInStock()
        {
            var quantityInStock = StockRepository.GetProductQuantityInStock(ExpectedOnlyProductName);
            var quantityInShoppingCart = _context.GetInitialProductQuantity();
            if (quantityInStock > quantityInShoppingCart)
            {
                StockRepository.UpdateStock(ExpectedOnlyProduct, quantityInShoppingCart);
            }
        }

        [Scope(Tag = ShoppingCartTestTag)]
        [Given(@"enough products in stock")]
        public void GivenEnoughProductsInStock()
        {
            var quantityInStock = StockRepository.GetProductQuantityInStock(ExpectedOnlyProductName);
            var quantityInShoppingCart = _context.GetInitialProductQuantity();
            if (quantityInStock <= quantityInShoppingCart)
            {
                StockRepository.UpdateStock(ExpectedOnlyProduct, quantityInShoppingCart + 1);
            }
        }

        [BeforeScenario(StockModifiedTestsTag)]
        public void SetOriginalStockQuantity()
        {
            _initialProductQuantity = StockRepository.GetProductQuantityInStock(ExpectedOnlyProductName);
        }

        [AfterScenario(StockModifiedTestsTag)]
        public void UpdateStockToOriginal()
        {
            StockRepository.UpdateStock(ExpectedOnlyProduct, _initialProductQuantity);
        }
    }
}
