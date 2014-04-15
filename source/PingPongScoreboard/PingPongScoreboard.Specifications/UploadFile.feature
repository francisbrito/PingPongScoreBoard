Feature: Upload a files containing scores
	In order to be able to write my own scores using a text editor
	As a referee
	I want to be able to upload text files to the application.

@exception
Scenario: I upload an empty file.
	Given I have a file named "scores.txt" containing the scores
	But it's empty
	When I press upload file
	Then an error should be shown saying "Unable to upload an empty file."

@exception
Scenario: I upload a file with an unknown format.
	Given I have a file named "scores.unknown" containing the scores
	But I don't know its format
	When I press upload file
	Then an error should be shown saying "Unknown file format."

Scenario: I upload a JSON file.
	Given I have a file named "scores.json" containing the scores
	And its format is JSON
	When I press upload file
	Then a game should be constructed using such scores

Scenario: I upload a text file.
	Given I have a file named "scores.txt" containing the scores
	And its format is plain text
	When I press upload file
	Then a game should be constructed using such scores