# Change shopping cart item quantity

As a shopper
I would like to be able to change quantity of shopping cart items
So that I can choose how many items I want to buy without going back to a shop.

## Acceptence criteria

### Decrement quantity when > 1

- Quantity > 1
- clicked button "-"
- => decremented quantity

### Cannot remove an item from a basket by decrementing quantity

- Quantity = 1
- clicked button "-"
- => unchanged quantity

### Increment quantity only when enough items in stock

- Enough items in stock
- clicked button "+"
- => incremented quantity

- Not enough items in stock
- clicked button "+"
- => unchanged quantity

### Edit quantity directly

- Clicked item quantity text box
- typed "2"
- => quantity is 2

### Quantity update will update total cost

- 1 item in basket, costs 60$.
- Displayed: Subtotal 60$, Order Total 60$ 
- Changed quantity to 2
- => Displayed: Subtotal 120$, Order Total 120$ 

### Reject invalid input

?

## Comments

- Editing quantity directly could be done in a text box.
- Decrementing and incrementing will probably require a +- button each.
- Quantity cannot be set to 0 or less (item must be deleted explicitly)
- Only whole numbers accepted