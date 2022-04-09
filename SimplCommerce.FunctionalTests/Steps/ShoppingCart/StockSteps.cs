using SimplCommerce.FunctionalTests.Db;
using static SimplCommerce.FunctionalTests.Steps.ShoppingCart.ShoppingCartTestContext;

namespace SimplCommerce.FunctionalTests.Steps.ShoppingCart
{
    [Binding]
    public class StockSteps
    {
        private const string StockModifiedTestsTag = "Stock";

        private readonly ScenarioContext _context;
        private int _quantityOfShoppingItem;

        public StockSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Scope(Tag = ShoppingCartTestTag)]
        [Given(@"not enough products in stock")]
        public void GivenNotEnoughProductsInStock()
        {
            var quantityInStock = StockRepository.GetProductQuantityInStock(ExpectedOnlyProductFullName);
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
            var quantityInStock = StockRepository.GetProductQuantityInStock(ExpectedOnlyProductFullName);
            var quantityInShoppingCart = _context.GetInitialProductQuantity();
            if (quantityInStock <= quantityInShoppingCart)
            {
                StockRepository.UpdateStock(ExpectedOnlyProduct, quantityInShoppingCart + 1);
            }
        }

        [BeforeScenario(StockModifiedTestsTag)]
        public void SetOriginalStockQuantity()
        {
            _quantityOfShoppingItem = StockRepository.GetProductQuantityInStock(ExpectedOnlyProductFullName);
        }

        [AfterScenario(StockModifiedTestsTag)]
        public void UpdateStockToOriginal()
        {
            StockRepository.UpdateStock(ExpectedOnlyProduct, _quantityOfShoppingItem);
        }
    }
}
