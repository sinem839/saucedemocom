Feature: Products_Page

Products page functionality

Background: User needs to be on products page
Given User is on the products page

@AddingItemToCart @RegressionTest @PositiveScenario
Scenario: Adding item to cart
	When User clicks to add to cart button
	Then The cart number must increase by one
	And The button for adding cart should change to "Remove"

@RemovingItemFromCart @RegressionTest @PositiveScenario
Scenario: Removing an item from cart
	When User clicks to add to cart button
	And He/she clicks to remove button
	Then The card number must be one less
	And The button for removing item should change to "Add to cart" 

@AddingMultipleItemsToCart @RegressionTest @PositiveScenario
Scenario: Adding multiple items to cart
	When User clicks to add to cart button of "Sauce Labs Onesie" item
	And User clicks to add to cart button of "Sauce Labs Backpack" item
	Then The cart number must increase by two
	And The button for adding cart of "Sauce Labs Onesie" item should change to "Remove"
	And The button for adding cart of "Sauce Labs Backpack" item should change to "Remove"

@AddingItemToCart @RegressionTest @PositiveScenario
Scenario: Adding an item and clicking on item description
	When User clicks to add to cart button
	And User clicks to item description in order to display added item
	Then User can remove that item from cart

@FilteringProducts @RegressionTest @PositiveScenario
Scenario: Filter products alphabetically
	When User selects Name (A to Z) "az" option
	Then The products are filtered alphabetically

@FilteringProducts @RegressionTest @PositiveScenario
Scenario: Filter products in reverse alphabetical order
	When User selects Name (Z to A) "za" option
	Then The products are filtered in reverse alphabetical order

@FilteringProducts @RegressionTest @PositiveScenario
Scenario: Filter products by price ascending
	When User selects Price (low to high) "lh" option
	Then The products are filtered in ascending price

@FilteringProducts @RegressionTest @PositiveScenario
Scenario: Filter products by price descending
	When User selects Price (high to low) "hl" option
	Then The products are filtered in descending price