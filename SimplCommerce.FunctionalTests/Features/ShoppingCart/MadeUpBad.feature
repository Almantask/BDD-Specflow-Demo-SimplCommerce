Feature: Shopping Cart

Scenario: Change quantity
Given I have "1" item in my shopping cart with a price of "60$"
When I type "1" in "ItemQuantityBox"
Then "ItemQuantityLabel" should have text "1"
And "TotalPrice" should have text "60$"
When I press button "+"
Then "ItemQuantityLabel" should have text "2"
And "TotalPrice" should have text "120$"
When I press button "-"
Then "ItemQuantityLabel" should have text "1"
And "TotalPrice" should have text "60$"

