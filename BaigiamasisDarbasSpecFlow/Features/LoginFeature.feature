Feature: LoginFeature
	

@mytag
Scenario: Correct login info
    Given navigate to login page
	Given input correct login name
	And input correct password
	Then the Logout button should be visible