Feature: Add scores to teams
	In order to determine a winner
	As a referee
	I want to be able to add scores to teams

Scenario: Add scores to a team
	Given a game is in session
	And team 1 has 0 points
	When I press add score
	And I choose team 1
	Then score for team 1 should be increased by one
