Feature: TestExpressionOfInterest
	In order to register expressions of interest to our annual tournament
	As a user
	I want to be told the sum of two numbers

@mytag
Scenario: Validate Empty EOI
	Given I have entered no data into my EOI
	When I try to validate my EOI
	Then the result should fail

	Scenario: Validate EOI with only Team Name
	Given I have an EOI with only the team name supplied
	When I try to validate my EOI
	Then the result should fail

	Scenario: Validate EOI with only Team Manager Name
	Given I have an EOI with only the team manager name
	When I try to validate my EOI
	Then the result should fail

	Scenario: Validate EOI with only Team contact email
	Given I have an EOI with only the team email address
	When I try to validate my EOI
	Then the result should fail
