Feature: Browse between sets
	In order to know what happened on a specific set
	As a referee
	I want to be able to browse between sets

@exception
Scenario: Attempting to browse before first set
	Given a game is in session
	And I'm watching the first set
	When I press go to previous set
	Then an error should be shown saying "Cannot browse before first set."

@exception
Scenario: Attempting to browse after last set
	Given a game is in session
	And I'm watching the last set
	When I press go to next set
	Then an error should be shown saying "Cannot browse after last set."

Scenario: Browsing to first set
	Given a game is in session
	When I press go to first set
	Then the current set should be the first one

Scenario: Browsing to last set
	Given a game is in session
	When I press go to last set
	Then the current set should be the last one

Scenario: Browsing to an specific set
	Given a game is in session
	And there are 11 sets in the game
	When I press go to specific set
	And I choose "5" as the set number
	Then the current set should be the set number 5

Scenario: Browsing to next set
	Given a game is in session
	And there are 11 sets in the game
	And the current set is set number 1
	When I press go to next set
	Then the current set should be the set number 2

Scenario: Browsing to previous set
	Given a game is in session
	And there are 11 sets in the game
	And the current set is set number 7
	When I press go to previous set
	Then the current set should be the set number 6