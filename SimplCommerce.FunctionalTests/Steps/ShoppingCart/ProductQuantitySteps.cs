namespace SimplCommerce.FunctionalTests.Steps.ShoppingCart
{
    [Binding]
    public class ProductQuantitySteps
    {
        [When(@"Ausra decrements product quantity")]
        public void WhenAusraDecrementsProductQuantity()
        {

        }

        [Given(@"product quantity is at least ([0-9]+)")]
        [Given(@"product quantity is ([0-9]+)")]
        public void GivenProductQuantityIs(int p0)
        {
            // quantity = p0;
        }

        [When(@"Ausra increments product quantity")]
        public void WhenAusraIncrementsProductQuantity()
        {

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
