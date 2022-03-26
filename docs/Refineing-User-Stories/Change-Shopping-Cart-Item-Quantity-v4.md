# Change shopping cart item quantity

As a shopper
I would like to be able to change quantity of shopping cart items
So that I can choose how many items I want to buy without going back to a shop.

## Acceptence criteria

When shopper increases quantity
Then quantity of the item is increased by 1

When shopper decreases quantity
Then quantity of the item is decreased by 1

Given item quantity is 1
When shopper decreases quantity
Then quantity and cost remains the same

When "2" for item quantity is typed
Then item quantity is 2

When "a" for item quantity is typed
Then input is rejected

When "-1" for item quantity is typed
Then input is rejected

When "1+1" for item quantity is typed
Then input is rejected

## Comments

- Editing quantity directly could be done in a text box.
- Decrementing and incrementing will probably require a +- button each.