namespace SimplCommerce.FunctionalTests.Steps.ShoppingCart
{
    [Binding]
    public class ItemQuantitySteps
    {
        [When(@"Sharon decrements item quantity")]
        public void WhenSharonDecrementsItemQuantity()
        {

        }

        [Then(@"item quantity is decremented")]
        public void ThenItemQuantityIsDecremented()
        {

        }

        [Given(@"item quantity is at least ([0-9]+)")]
        [Given(@"item quantity is ([0-9]+)")]
        public void GivenItemQuantityIs(int p0)
        {
            // quantity = p0;
        }

        [Then(@"item quantity is unchanged")]
        public void ThenItemQuantityIsUnchanged()
        {

        }

        [When(@"Sharon increments item quantity")]
        public void WhenSharonIncrementsItemQuantity()
        {

        }

        [Then(@"item quantity is incremented")]
        public void ThenItemQuantityIsIncremented()
        {

        }

        [When(@"Sharon sets item quantity to (.*)")]
        public void WhenSharonSetsItemQuantityTo(int p0)
        {

        }

        [When(@"Sharon sets item quantity")]
        public void WhenSharonSetsItemQuantity()
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

        [Then(@"item quantity should be (.*)")]
        public void ThenItemQuantityShouldBe(int p0)
        {
            throw new PendingStepException();
        }
    }
}
