Feature: Add scores to teams
	In order to determine a winner
	As a referee
	I want to be able to add scores to teams

Scenario: Add scores to a team
	Given a game is in session
	And there's a team called "team one"
	When I press add score
	And I choose "team one"
	Then team one' score should be increased by one.
