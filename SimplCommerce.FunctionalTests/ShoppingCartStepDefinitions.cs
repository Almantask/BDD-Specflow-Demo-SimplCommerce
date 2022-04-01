using System;
using TechTalk.SpecFlow;

namespace SimplCommerce.FunctionalTests
{
    [Binding]
    public class ShoppingCartStepDefinitions
    {
        [Given(@"I have ""([^""]*)"" item in my shopping cart with a price of ""([^""]*)""")]
        public void GivenIHaveItemInMyShoppingCartWithAPriceOf(string p0, string p1)
        {
            throw new PendingStepException();
        }

        [When(@"I type ""([^""]*)"" in ""([^""]*)""")]
        public void WhenITypeIn(string p0, string itemQuantityBox)
        {
            throw new PendingStepException();
        }

        [Then(@"""([^""]*)"" should have text ""([^""]*)""")]
        public void ThenShouldHaveText(string itemQuantityLabel, string p1)
        {
            throw new PendingStepException();
        }

        [When(@"I press button ""([^""]*)""")]
        public void WhenIPressButton(string p0)
        {
            throw new PendingStepException();
        }
    }
}
