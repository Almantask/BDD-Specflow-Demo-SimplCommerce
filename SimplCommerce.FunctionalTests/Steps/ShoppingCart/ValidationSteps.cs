using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.FunctionalTests.Steps.ShoppingCart
{
    public class ValidationSteps
    {
        [Then(@"item quantity input is rejected")]
        public void ThenItemQuantityInputIsRejected()
        {
            throw new PendingStepException();
        }
    }
}
