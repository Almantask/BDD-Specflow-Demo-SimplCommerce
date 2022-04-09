@ShoppingCart
Feature: Change item quantity

As Ausra the shopper
I would like to be able to change quantity of shopping cart items
So that I can choose how many items I want to buy without going back to a shop.

Background:
    Given Shopping cart contains an item

Scenario: Decrement quantity when item quantity in shopping cart is enough
    Given item quantity is at least 2
    When Ausra decrements item quantity
    Then item quantity should be decremented

Scenario: Cannot remove an item from a basket by decrementing quantity
    Given item quantity is 1
    When Ausra decrements item quantity
    Then item quantity should be unchanged

Scenario: Increment quantity when enough items in stock
    Given enough items in stock
    When Ausra increments item quantity
    Then item quantity should be incremented

Scenario: Increment quantity is not allowed when not enough items in stock
    Given not enough items in stock
    When Ausra increments item quantity
    Then item quantity should be unchanged

Scenario: Edit quantity directly changes quantity
    When Ausra sets item quantity to <valid number>
    Then item quantity should be <valid number>
Examples:
    | valid number |
    | 1            |
    | 10           |
    | +1           |

Scenario: Edit quantity directly with invalid input rejects it
    When Ausra sets item quantity to <invalid number>
    Then item quantity input should be rejected
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

Scenario: Quantity update will update total cost
    When Ausra sets item quantity
    Then shopping cart display Subtotal and Order Total should be updated