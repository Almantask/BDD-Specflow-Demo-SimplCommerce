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

"1" for item quantity is okay, because it could also be interpreted as text or as a variable. In any case, we need to be exact. We could rename it from "1" to 1. But it would make step binding significantly more difficult to implement.

Then item quantity is unchanged

## Dilema 2 - Dry vs Damp