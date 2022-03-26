@ShoppingCart
Feature: Change item quantity

As Sharon the shopper
I would like to be able to change quantity of shopping cart items
So that I can choose how many items I want to buy without going back to a shop.

Scenario: Decrement quantity when at least 2 items in the basket
    Given item quantity is at least 2
    When a shopper decrements item quantity
    Then item quantity is decremented

Scenario: Cannot remove an item from a basket by decrementing quantity
    Given item quantity is 1
    When a shopper decrements item quantity
    Then item quantity is unchanged

Scenario: Increment quantity when enough items in stock
    Given enough items in stock
    When a shopper decrements item quantity
    Then item quantity is incremented

Scenario: Increment quantity is not allowed when not enough items in stock
    Given not enough items in stock
    When a shopper increments item quantity
    Then item quantity is unchanged

Scenario: Edit quantity directly changes quantity. Only positive whole numbers accepted.
    Given a shopper wants to change item quantity directly
    When a shopper types <valid number>
    Then item quantity changes to that number
Examples:
    | whole positive number |
    | 1                     |
    | 10                    |
    | +1                    |

Scenario: Edit quantity directly with invalid input rejects it
    Given a shopper wants to change item quantity directly
    # Directly is not intuitive, consider rewording
    When a shopper types <invalid number>
    Then item quantity input is rejected
Examples:
    | description          | invalid number |
    | Negative             | -1             |
    | Zero                 | 0              |
    | Number with fraction | 1.5            |
    | More than in stock   | 99             |
    | Roman number         | I              |
    | Letter               | a              |
    | No arithmetics       | 1+1            |
    | Blank                |                |

Scenario: Quantity update will update total cost
    Given a shopper has a single pair of sport shoes for 60$
    When a shopper increments item quantity
    Then shopping cart display shows Subtotal "120$", Order Total "120$"