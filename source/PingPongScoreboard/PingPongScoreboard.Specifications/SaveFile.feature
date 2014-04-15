Feature: Save a file containing the scores
	In order to retrieve scores later
	As a referee
	I want to be to save a file containing the scores of a game

Scenario: Save a JSON file
	Given a game is in session
	When I press save game
	And I choose "scores.json" as file name
	And I choose JSON format as file format
	Then a JSON file named "scores.json" containing the scores should be created.

Scenario: Save a text file
	Given a game is in session
	When I press save game
	And I choose "scores.txt" as file name
	And I choose text format as file format
	Then a text file named "scores.txt" containing the scores should be created.