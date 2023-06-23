Feature: Login_Page

   Login functionality of saucedemo.com

Background: User needs to be on login page
Given User is on the login page

@SuccessfulLogin @RegressionTest @PositiveScenario
Scenario: Login successfully
	When User enters a username "<usernames>" and password "<passwords>"
	And User clicks the login button
	Then User should be redirected to the products page
	Examples:
		| usernames               | passwords    |
		| standard_user           | secret_sauce |
		| locked_out_user         | secret_sauce |
		| problem_user            | secret_sauce |
		| performance_glitch_user | secret_sauce |

@UnsuccessfulLogin @RegressionTest @NegativeScenario
Scenario: Invalid username
	When User enters an invalid username "test" and password "secret_sauce"
	And User clicks the login button
	Then User should receive an error message as "Username and password do not match any user in this service"

@UnsuccessfulLogin @RegressionTest @NegativeScenario
Scenario: Invalid password
	When User enters an username "performance_glitch_user" and invalid password "test"
	And User clicks the login button
	Then User should receive an error message as "Username and password do not match any user in this service"

@UnsuccessfulLogin @RegressionTest @NegativeScenario
Scenario: No username
	When User enters a password "secret_sauce" without username
	And User clicks the login button
	Then User should receive an error message as "Username is required"

@UnsuccessfulLogin @RegressionTest @NegativeScenario
Scenario: No password
	When User enters a username "locked_out_user" without password
	And User clicks the login button
	Then User should receive an error message as "Password is required"

@UnsuccessfulLogin @RegressionTest @NegativeScenario
Scenario: No username or password
	When User doesn't enter any information
	And User clicks the login button
	Then User should receive an error message as "Username is required"

