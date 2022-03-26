# Change shopping cart item quantity

As a shopper
I would like to be able to change quantity of shopping cart items
So that I can choose how many items I want to buy without going back to a shop.

## Acceptence criteria

### Decrement quantity when > 1

- Quantity > 1
- increment quantity
- => decremented quantity

### Cannot remove an item from a basket by decrementing quantity

- Quantity = 1
- chose to decrement quantity
- => unchanged quantity

### Increment quantity when enough items in stock

- Enough items in stock
- increment quantity
- => incremented quantity

### Increment quantity is not allowed when not enough items in stock

- Not enough items in stock
- increment quantity
- => unchanged quantity

### Edit quantity directly changes quantity

- change quantity directly
- typed "2"
- => quantity is 2

### Edit quantity directly with invalid input rejects it

- change quantity directly
- typed invalid quantity
- => input rejected

### Quantity update will update total cost

- 1 item in basket, costs 60\$.
- Displayed: Subtotal 60\$, Order Total 60\$ 
- Changed quantity to 2
- => Displayed: Subtotal 120\$, Order Total 120\$ 

## Open Questions

- How should we reject input? 
- Should input rejected right after invalid character is typed or later?
- What if we change quantity directly to a valid number, but when not enough items in stock? When should that be detected?

## Comments

- Editing quantity directly could be done in a text box.
- Decrementing and incrementing will probably require a +- button each.
- Quantity cannot be set to 0 or less (item must be deleted explicitly)
- Only whole numbers accepted