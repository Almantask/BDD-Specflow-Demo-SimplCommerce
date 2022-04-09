

namespace SimplCommerce.FunctionalTests.Steps.ShoppingCart
{
    [Binding]
    public class ValidationSteps
    {
        [Then(@"item quantity input should be rejected")]
        public void ThenItemQuantityInputShouldBeRejected()
        {
            throw new PendingStepException();
        }
    }
}
