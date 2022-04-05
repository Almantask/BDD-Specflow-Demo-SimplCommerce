Feature: CasualShopperJourney

Most users browse for a few items:
- search some
- add a few
- inspect a few
- remove a few 
- and go straight to a shopping cart to checkout

Shona is a registered shopper.

Scenario: 2 items added, 1 revi 1 removed, checkout
When Shona types "samsung" in the search bar
Then "Samsung Galaxy A5" appears on the screen
When Shona inspects "Samsung Galaxy A5"
Then "Samsung Galaxy A5" details open
When Shona adds item to cart
Then a pop up indicating the item was added appears
Given Shona closes the pop up
And navigates to tablets
When Shona inspects "iPad Pro Wi-Fi 4G 128GB"
Then "iPad Pro Wi-Fi 4G 128GB" details open
Given Shona changes item quantity to 2
When Shona adds item to a shopping cart
Then a pop up indicating the item was added appears
When Shona navigates to shopping cart page
Then shopping cart should have the following items:
* 2 "Samsung Galaxy A5"
* 1 "iPad Pro Wi-Fi 4G 128GB"
When Shona decrements "Samsung Galaxy A5" quantity
Then shopping cart should have the following items:
* 1 "Samsung Galaxy A5"
* 1 "iPad Pro Wi-Fi 4G 128GB"
When Shona proceeds to checkout
Then address details window appears
...

