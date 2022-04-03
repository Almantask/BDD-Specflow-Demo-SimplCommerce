Feature: Fake

A short summary of the feature

Scenario: Increase item quantity when a single item
    Given a shopper has added "Samsung Galaxy A5 Pink" to their shopping cart
	And a shopper has navigated to "https://demo.simplcommerce.com/cart"
	When button "+" is clicked
	Then "ItemQuantityTextBox" should have text "2"

Scenario: Increase item quantity when a single item1
    Given a shopper has added "Samsung Galaxy A5 Pink" to their shopping cart
	And a shopper has navigated to shopping cart page
	When button "+" is clicked
	Then item quantity should be 2

    Scenario: Increase item quantity when a single item2
    Given a shopper has a single item in their cart
	And a shopper has navigated to shopping cart page
	When button "+" is clicked
	Then item quantity should be 2

Scenario: Increase item quantity when a single item3
    Given a shopper has a single item in their cart
	When a shopper increments quantity
	Then item quantity should be 2

Scenario: Increase item quantity when a single item4
    * a shopper has a single item in their cart
	* a shopper increments quantity
	* item quantity should be 2

