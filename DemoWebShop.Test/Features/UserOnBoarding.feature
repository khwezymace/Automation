Feature: UserOnBoarding

A short summary of the feature

@tag1
Scenario: User Registration
	Given the user navigates to the site
	When the user clicks on the register tab
	And the user enters registration details
	And the user clicks on the register button
	Then the user should be successfully registered.

@tag1
Scenario: User Login
	Given the user navigates to the site
	When  the user clicks on the login tab
	And the user enters login details
	And the user clicks on the login button
	Then  the user should be successfully logged in

@tag1
Scenario: User Verifies Computers Page
	Given the user navigates to the site
	When  the user clicks on the login tab
	And the user enters login details
	And the user clicks on the login button
	And the user clicks on the computers tab
	Then  the user should be redirected on the computers page.