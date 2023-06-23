Feature: Checkout_Page

Checkout page functionality

@CheckOutSuccessfully @RegressionTest @PositiveScenario
Scenario: Checkout successfully
Given User has logged into the system as "standard_user" with the password "secret_sauce"
And User is in the checkout page 
When User fills out "<firstname>", "<lastname>" and "<postalcode>"
And User enter to "Continue" button
Then User should be directed to the checkout overview page

@CheckOutUnsuccessfully @RegressionTest @NegativeScenario
Scenario: Checkout without first name
Given User has logged into the system as "standard_user" with the password "secret_sauce"
And User is in the checkout page 
When User fills out "<input1>" and "<input2>"
And User enter to "Continue" button
Then User should receive the error message as "<error>"
Examples:
	| input1    | input2   | error                   |
	| lastname  | postcode | First Name is required  |
	| firstname | postcode | Last Name is required   |
	| firstname | lastname | Postal Code is required |

@CheckOutUnsuccessfully @RegressionTest @NegativeScenario
Scenario: Checkout without entering information
Given User has logged into the system as "standard_user" with the password "secret_sauce"
And User is in the checkout page 
When User clicks to "Continue" button without entering any information
Then User should receive the error message as "First Name is required"

@CheckOutUnsuccessfully @RegressionTest @NegativeScenario
Scenario: Return to your cart page
Given User has logged into the system as "standard_user" with the password "secret_sauce"
And User is in the checkout page 
When User enter to "Cancel" button
Then User should be directed to the your cart page
