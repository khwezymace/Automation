Feature: UserOnBoarding

A short summary of the feature

@tag1
Scenario: User Registration
	Given the user navigates to the site
	When the user clicks on the register tab
	And the user enters registration details
	Then the user clicks on the register button

@tag1
Scenario: User Login
	Given the user navigates to the site
	When  the user clicks on the login tab
	And the user enters login details
	And the user clicks on the login button
	Then  the user should be successfully logged in


@tag1 
Scenario: User navigates to the Desktop page
Given the user navigates to the site
	When  the user clicks on the login tab
	And the user enters login details
	And the user clicks on the login button
	And the user clicks on the computers tab
	And the user clicks on the desktop option from the dropdown.
	Then the user should be redirected to the deskstop option page.

@tag1
Scenario: User sorts deskstop by all options
Given the user navigates to the site
	When  the user clicks on the login tab
	And the user enters login details
	And the user clicks on the login button
	And the user clicks on the computers tab
	And the user clicks on the desktop option from the dropdown.
	And the user selects the sortBy dropdown using all options
	Then the desktop products should be orderby the given options.