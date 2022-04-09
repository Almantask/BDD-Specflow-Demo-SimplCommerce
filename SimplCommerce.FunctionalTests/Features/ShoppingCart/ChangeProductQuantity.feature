@ShoppingCart
Feature: Change product quantity

As Ausra the shopper
I would like to be able to change quantity of shopping cart products
So that I can choose how many products I want to buy without going back to a shop.

Background:
    Given Shopping cart contains a product

@ignore
Scenario: Decrement quantity when product quantity in shopping cart is enough
    Given product quantity is at least 2
    When Ausra decrements product quantity
    Then product quantity should be decremented

@ignore
Scenario: Cannot remove a product from a basket by decrementing quantity
    Given product quantity is 1
    When Ausra decrements product quantity
    Then product quantity should be unchanged

@Stock
Scenario: Increment quantity when enough products in stock
    Given enough products in stock
    When Ausra increments product quantity
    Then product quantity should be incremented

@Stock
Scenario: Increment quantity is not allowed when not enough products in stock
    Given not enough products in stock
    When Ausra increments product quantity
    Then product quantity should be unchanged

@ignore
Scenario: Edit quantity directly changes quantity
    When Ausra sets product quantity to <valid number>
    Then product quantity should be <valid number>
Examples:
    | valid number |
    | 1            |
    | 10           |
    | +1           |

@ignore
Scenario: Edit quantity directly with invalid input rejects it
    When Ausra sets product quantity to <invalid number>
    Then product quantity input should be rejected
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

@OrderSummary
Scenario: Quantity update will update total cost
    When Ausra sets product quantity
    Then shopping cart display Subtotal and Order Total should be updated