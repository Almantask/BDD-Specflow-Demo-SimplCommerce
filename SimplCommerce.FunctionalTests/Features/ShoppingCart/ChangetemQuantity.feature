Feature: Change item quantity

As Sharon the shopper
I would like to be able to change quantity of shopping cart items
So that I can choose how many items I want to buy without going back to a shop.

@ShoppingCart
Scenario: Test
	Given precondition
	When I action
	Then I should see

@ShoppingCart
Scenario: Decrement quantity when > 1
Given item quantity is more than 1
When a shopper increments quantity
Then item quantity is "1"

@ShoppingCart
Scenario: Cannot remove an item from a basket by decrementing quantity

- Quantity = 1
- chose to decrement quantity
- => unchanged quantity

@ShoppingCart
Scenario: Increment quantity when enough items in stock

- Enough items in stock
- chose to increment quantity
- => incremented quantity

@ShoppingCart
Scenario: Increment quantity is not allowed when not enough items in stock

- Not enough items in stock
- chose to increment quantity
- => unchanged quantity

@ShoppingCart
Scenario: Edit quantity directly changes quantity

- Chose to change quantity directly
- typed "2"
- => quantity is 2

@ShoppingCart
Scenario: Edit quantity directly with invalid input rejects it

- Chose to change quantity directly
- typed invalid quantity
- => input rejected

@ShoppingCart
Scenario: Quantity update will update total cost

- 1 item in basket, costs 60\$.
- Displayed: Subtotal 60\$, Order Total 60\$ 
- Changed quantity to 2
- => Displayed: Subtotal 120\$, Order Total 120\$ 
