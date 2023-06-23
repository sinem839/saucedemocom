Feature: Your_Card_Page

Cart page functionality

@CartInfo @RegressionTest @PositiveScenario
Scenario: Continue Shopping
	Given User need to log into the system
	And User switches to cart page
	When User clicks continue shopping button
	Then User should be directed to the products page

@CartInfo @RegressionTest @PositiveScenario
Scenario: Remove Item
	Given User need to log into the system
	And User clicks to add to cart button of "Sauce Labs Backpack" item
	And User switches to cart page
	When User clicks remove button of "Sauce Labs Backpack" item
	Then The product should be removed from the card

@CartInfo @RegressionTest @PositiveScenario
Scenario: Checkout Item
	Given User need to log into the system
	And User clicks to add to cart button of "Sauce Labs Backpack" item
	And User switches to cart page
	When User clicks the checkout button
	Then User should be on the checkout page

