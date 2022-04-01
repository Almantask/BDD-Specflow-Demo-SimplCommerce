# Formulating Scenarios

First pat of BDD - discovery, should yield nice examples. Second part of BDD - formulation - converts examples to scenarios in a form of feature files.

## Dilema 1 - Easy to implement, harder to understand

It's very easy to automate the following:

```gherkin
@ShoppingCart
Scenario: Decrement quantity when > 1
Given item quantity is "2"
When a shopper decrements quantity
Then item quantity is "1"
```

However, what does 2 mean? Though easy to implement, the intended meaning might be hidden.
To make it more readable - we should use something like "more than 1".

Scenario: Cannot remove an item from a basket by decrementing quantity
    Given item quantity is 1
    When Sharon decrements item quantity
    Then item quantity is unchanged

This might work for the first scenario, but for the second scenario it would feel a bit awkward.


"1" for item quantity is okay, because it could also be interpreted as text or as a variable. In any case, we need to be exact. We could rename it from "1" to 1. But it would make step binding significantly more difficult to implement.

Then item quantity is unchanged

## Dilema 2 - Dry vs Damp

background worked

Quantity update will update total cost

Could have written to verify subtotals unchanged. But we didn't. Could have appeneded to every scenario, but it would ruin readability.

Scenario: Quantity update will update total cost
    When Sharon changes item quantity via <method of changing item quantity>
    Then shopping cart display updates Subtotal and Order Total
        | method of changing item quantity |
        | increment                        |
        | decrement                        |
        | set                              |

        Would this work on unit tests? No, too much noise just to get this aspect separated. It is not as much documentable and a risk of not catching bugs is too high.

        Could have written more scenarios, but the key point is to document behavior.
        Explain why we didn't test all the different ways of updating quantity.

## Dilema 3 - Where to put my steps?

https://github.com/JD-Innovensa/InMemoryPlaywrightDemo

## Ambigious steps?

Given item quantity is at least 2
Given item quantity is 2

When in assertion...

## Dilema 4 - too many examples

Refer to business experiences the other day.
5 scenarios. Do we need 5 new tests?
Those are just illustrations. I could have added a lot more.