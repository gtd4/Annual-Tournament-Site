Feature: TestExpressionOfInterest
	In order to register expressions of interest to our annual tournament
	As a user
	I want to be told the sum of two numbers

@mytag
	Scenario: Validate EOI with Team name missing
	Given I have an EOI with the team name missing
	When I try to validate my EOI
	Then the result should be false

	Scenario: Validate EOI with team manager missing
	Given I have an EOI with the team name missing
	When I try to validate my EOI
	Then the result should be false

	Scenario: Validate EOI with Team contact email missing
	Given I have an EOI with the team contact email missing
	When I try to validate my EOI
	Then the result should be false

	Scenario: Validate email address
	Given I have an email address of gav.com
	When I try to validate the address
	Then the result should be false

	Scenario: Validate EOI
	Given I have an EOI with the team manager name as Gavin
	And the team as Saiyans
	And the email address as gtd005@gmail.com
	When I try to validate my EOI
	Then the result should be true

