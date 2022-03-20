# Change shopping cart item quantity

As a shopper
I would like to be able to change quantity of shopping cart items
So that I can choose how many items I want to buy without going back to a shop.

## Acceptence criteria

When button "+" is Clicked
Then quantity of the item is increased by 1

When button "-" is clicked
Then quantity of the item is decreased by 1

Given item quantity is 1
When button "-" is clicked
Then quantity and cost remains the same

When item quantity text box is clicked
Then a new quantity can be typed

When item quantity text box is clicked
And "a" is typed
Then input is rejected

When item quantity text box is clicked
And "-1" is typed
Then input is rejected

When item quantity text box is clicked
And "1+1" is typed
Then input is rejected

## Comments

- Editing quantity directly could be done in a text box.
- Decrementing and incrementing will probably require a +- button each.