namespace SimplCommerce.FunctionalTests.Steps.ShoppingCart
{
    public static class ShoppingCartTestContext
    {
        public const string ShoppingCartTestTag = "ShoppingCart";
        public const string ExpectedOnlyProduct = "Square Neck Back";
        public const string ExpectedOnlyProductFullName = "Square Neck Back Silver S";


        public static void SetProductQuantity(this ScenarioContext context, int quantity)
        {
            context.Add(ExpectedOnlyProduct, quantity);
        }

        public static int GetProductQuantity(this ScenarioContext context)
        {
            return (int)context[ExpectedOnlyProduct];
        }
    }
}
