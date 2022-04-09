namespace SimplCommerce.FunctionalTests.Steps.ShoppingCart
{
    [Binding]
    public class ItemQuantitySteps
    {
        [When(@"Ausra decrements item quantity")]
        public void WhenAusraDecrementsItemQuantity()
        {

        }

        [Given(@"item quantity is at least ([0-9]+)")]
        [Given(@"item quantity is ([0-9]+)")]
        public void GivenItemQuantityIs(int p0)
        {
            // quantity = p0;
        }

        [When(@"Ausra increments item quantity")]
        public void WhenAusraIncrementsItemQuantity()
        {

        }

        [When(@"Ausra sets item quantity to (.*)")]
        public void WhenAusraSetsItemQuantityTo(int p0)
        {

        }

        [When(@"Ausra sets item quantity")]
        public void WhenAusraSetsItemQuantity()
        {

        }

        [Then(@"item quantity should be decremented")]
        public void ThenItemQuantityShouldBeDecremented()
        {
            throw new PendingStepException();
        }

        [Then(@"item quantity should be unchanged")]
        public void ThenItemQuantityShouldBeUnchanged()
        {
            throw new PendingStepException();
        }

        [Then(@"item quantity should be incremented")]
        public void ThenItemQuantityShouldBeIncremented()
        {
            throw new PendingStepException();
        }
    }
}
