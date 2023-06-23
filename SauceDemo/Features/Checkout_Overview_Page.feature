Feature: Checkout_Overview_Page

Checkout overview page functionality

@CancelOrder @RegressionTest @PositiveScenario
Scenario: Back to the products page
Given User has logged into the system
And User is on the checkout overview page
When User clicks to "Cancel" button
Then User should be directed to the Products Page

@CompleteTheProcess @RegressionTest @PositiveScenario
Scenario: Sending product(s)' order
Given User has logged into the system
And User is on the checkout overview page 
When User clicks to "Finish" button
Then Order operation should be completed

