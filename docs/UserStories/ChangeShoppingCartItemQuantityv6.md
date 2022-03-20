# Change shopping cart item quantity

As a shopper
I would like to be able to change quantity of shopping cart items
So that I can choose how many items I want to buy without going back to a shop.

## Acceptence criteria

### Decrement quantity when > 1

- Quantity > 1
- button "-" is clicked
- => quantity is decremented

### Cannot remove an item from a basket by decrementing quantity

- Quantity = 1
- button "-" is clicked
- => quantity remains the same

### Increment quantity only when enough items in stock

- Enough items in stock
- button "+" is clicked
- => quantity is incremented

- Not enough items in stock
- button "+" is clicked
- => quantity remains the same

### Edit quantity directly

- Clicked item quantity text box and typed "2"
- => quantity is changed to "2"

### Quantity update will update total cost

- 1 item in basket, costs 60$.
- Displayed: Basket Totals 60$, Item Totals 60$ 
- Changed quantity to 2
- => Displayed: Basket Totals 120$, Item Totals 120$ 

## Open Questions

- What happens when the user types -1 in quantity? What about a letter?
  - It should reset the quantity, but when?

## Comments

- Editing quantity directly could be done in a text box.
- Decrementing and incrementing will probably require a +- button each.
- Quantity cannot be set to 0 or less (item must be deleted explicitly)
- Only whole numbers accepted