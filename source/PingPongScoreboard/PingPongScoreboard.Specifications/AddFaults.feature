Feature: Add faults to teams
	In order to keep track of faults made during a game.
	As a referee
	I want to be able to add faults to teams

Scenario: Add fault to a team.
	Given a game is in session
	When I press add fault
	And I choose team 1
	Then fault count for team 1 should be increased by one
