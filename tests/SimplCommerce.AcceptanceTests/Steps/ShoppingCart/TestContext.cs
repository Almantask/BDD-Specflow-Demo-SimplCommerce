namespace SimplCommerce.AcceptanceTests.Steps.ShoppingCart
{
    public static class TestContext
    {
        public const string ShoppingCartTestTag = "ShoppingCart";
        public const string ExpectedOnlyProduct = "Square Neck Back";
        public const string ExpectedOnlyProductFullName = "Square Neck Back Silver S";

        public static void SetInitialProductQuantity(this ScenarioContext context, int quantity)
        {
            if (context.ContainsKey(ExpectedOnlyProduct))
            {
                context[ExpectedOnlyProduct] = quantity;
            }
            else
            {
                context.Add(ExpectedOnlyProduct, quantity);
            }
        }

        public static int GetInitialProductQuantity(this ScenarioContext context)
        {
            return (int)context[ExpectedOnlyProduct];
        }
    }
}
