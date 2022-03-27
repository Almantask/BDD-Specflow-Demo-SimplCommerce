@ShoppingCart
Feature: Change item quantity

As Sharon the shopper
I would like to be able to change quantity of shopping cart items
So that I can choose how many items I want to buy without going back to a shop.

Background: Sharon has a single item in the basket

Scenario: Decrement quantity when at least 2 items in the basket
    Given item quantity is at least 2
    When Sharon decrements item quantity
    Then item quantity is decremented

Scenario: Cannot remove an item from a basket by decrementing quantity
    Given item quantity is 1
    When Sharon decrements item quantity
    Then item quantity is unchanged

Scenario: Increment quantity when enough items in stock
    Given enough items in stock
    When Sharon increments item quantity
    Then item quantity is incremented

Scenario: Increment quantity is not allowed when not enough items in stock
    Given not enough items in stock
    When Sharon increments item quantity
    Then item quantity is unchanged

Scenario: Edit quantity directly changes quantity. Only positive whole numbers accepted.
    When Sharon sets item quantity to <valid number>
    Then item quantity is <valid number>
Examples:
    | valid number |
    | 1            |
    | 10           |
    | +1           |

Scenario: Edit quantity directly with invalid input rejects it
    When Sharon sets item quantity to <invalid number>
    Then item quantity input is rejected
Examples:
    | description          | invalid number |
    | Negative             | -1             |
    | Zero                 | 0              |
    | Number with fraction | 1.5            |
    | More than in stock   | 99             |
    | Roman number         | I              |
    | Letter               | a              |
    | Arithmetics          | 1+1            |
    | Blank                |                |

# What if this was appended to other scenarios?
Scenario: Quantity update will update total cost
    When Sharon changes item quantity via <method of changing item quantity>
    Then shopping cart display updates Subtotal and Order Total
        | method of changing item quantity |
        | increment                        |
        | decrement                        |
        | set                              |