Feature: Adding Details to User Profile
	In order to allow buyers to see my details
	As a seller of skills
	I want to be able to add details to my profile

@mytag
Scenario: Edit availability
	Given a web browser is on the Profile page
	When the user clicks on the availability edit button
	And the user selects an availabilty type
	Then that availability type should be displayed on the profile

@mytag
Scenario: Edit weekly hours
	Given a web browser is on the Profile page
	When the user clicks on the hours edit button
	And the user selects a week hours selection
	Then that hours selection should be displayed on the profile

@mytag
Scenario Outline: Edit earn target
	Given a web browser is on the Profile page
	When the user clicks on the earn target edit button
	And the user selects an earnings target of <targetId>
	Then an earnings target of "<targetValue>" should be displayed

	Examples: 
	| targetId | targetValue                      |
	| 0        | Less than $500 per month         |
	| 1        | Between $500 and $1000 per month |
	| 2        | More than $1000 per month        |

@mytag
Scenario: Edit description
	Given a web browser is on the Profile page
	When the user clicks on the description edit button
	And the user enters a description
	Then that description should be displayed on the profile

@mytag
Scenario: Be unable to add an empty description
	Given a web browser is on the Profile page
	When the user clicks on the description edit button
	And the user enters an empty description
	Then an invalid empty description error message should be displayed
	And that description should not be displayed on the profile

@mytag
Scenario: Be unable to edit a description so that is empty
	Given a web browser is on the Profile page
	And the description is not empty
	When the user clicks on the description edit button
	And the user enters an empty description
	Then an invalid empty description error message should be displayed
	And that description should not be displayed on the profile

@mytag
Scenario: Edit location
	Given a web browser is on the Profile page
	When the user clicks on the location map
	And the user selects their location
	Then that location should be displayed on the profile

@mytag
Scenario: Edit first name
	Given a web browser is on the Profile page
	When the user clicks on their name
	And the user updates their first name
	Then that new first name should be displayed on the profile

@mytag
Scenario: Be unable to edit a first name so that is empty
	Given a web browser is on the Profile page
	When the user clicks on their name
	And the user updates their first name to be empty
	Then an invalid first name error message should be displayed
	And that first name should not be updated on the profile

@mytag
Scenario: Edit last name
	Given a web browser is on the Profile page
	When the user clicks on their name
	And the user updates their last name
	Then that new last name should be displayed on the profile

@mytag
Scenario: Be unable to edit a last name so that is empty
	Given a web browser is on the Profile page
	When the user clicks on their name
	And the user updates their last name to be empty
	Then an invalid last name error message should be displayed
	And that last name should not be updated on the profile

@mytag
Scenario: Add a language
	Given a web browser is on the Profile page
	And the Languages tab has been selected
	When the user clicks on the Add New button
	And the user enters the new language details
	Then that language should be displayed on the profile

@mytag
Scenario: Be unable to add a language with empty language name
	Given a web browser is on the Profile page
	And the Languages tab has been selected
	When the user clicks on the Add New button
	And the user enters the language with empty language name
	Then an error message should be displayed
	And that language should not be displayed on the profile

@mytag
Scenario: Be unable to add a language without selecting language level
	Given a web browser is on the Profile page
	And the Languages tab has been selected
	When the user clicks on the Add New button
	And the user enters the language without selecting language level
	Then an error message should be displayed
	And that language should not be displayed on the profile

@mytag
Scenario: Be unable to add a language without selecting any language details
	Given a web browser is on the Profile page
	And the Languages tab has been selected
	When the user clicks on the Add New button
	And the user enters the language without any language details
	Then an error message should be displayed
	And that language should not be displayed on the profile

@mytag
Scenario: Be unable to add more than 4 languages
	Given a web browser is on the Profile page
	And the Languages tab has been selected
	And the language list contains at least 4 languages
	Then the Add New language button should not be displayed

@mytag
Scenario: Edit a language name
	Given a web browser is on the Profile page
	And the Languages tab has been selected
	And the languages list is not empty
	When the user clicks on the edit language button
	And the user updates the name of the language
	Then that updated language name should be displayed on the profile

@mytag
Scenario: Edit a language level
	Given a web browser is on the Profile page
	And the Languages tab has been selected
	And the languages list is not empty
	When the user clicks on the edit language button
	And the user updates the level of the language
	Then that updated language level should be displayed on the profile

@mytag
Scenario Outline: Edit a language details
	Given a web browser is on the Profile page
	And the Languages tab has been selected
	And the languages list has at least <listPosition> languages
	When the user clicks on the edit language button in position <listPosition>
	And the user updates the "<languageName>" and <levelId> of the language
	Then that updated "<languageName>" and "<levelValue>" should be displayed in position <listPosition>

	Examples: 
	| listPosition | languageName | levelId | levelValue       |
	| 1            | English      | 5       | Native/Bilingual |
	| 2            | Spanish      | 2       | Basic            |
	| 3            | Japanese     | 3       | Conversational   |
	| 4            | Chinese      | 4       | Fluent           |

@mytag
Scenario: Be unable to edit a language if the language list is empty
	Given a web browser is on the Profile page
	And the Languages tab has been selected
	And the languages list is empty
	Then the edit language button should not be displayed

@mytag
Scenario: Be unable to edit a language name so that it is empty
	Given a web browser is on the Profile page
	And the Languages tab has been selected
	And the languages list is not empty
	When the user clicks on the edit language button
	And the user edits the name of the language so that it is empty
	Then an error message should be displayed
	And the language name should not be updated

@mytag
Scenario: Be unable to edit a language level to Choose Language Level
	Given a web browser is on the Profile page
	And the Languages tab has been selected
	And the languages list is not empty
	When the user clicks on the edit language button
	And the user selects the Level to be Choose Language Level
	Then an error message should be displayed
	And the language should not be updated

@mytag
Scenario: Be unable to add a new language while editing a different languages details
	Given a web browser is on the Profile page
	And the Languages tab has been selected
	And the languages list is not empty
	When the user clicks on the edit language button
	And the user enters the new language details
	Then an error message should be displayed
	And the language should not be displayed

@mytag
Scenario Outline: Delete a language
	Given a web browser is on the Profile page
	And the Languages tab has been selected
	And the languages list has at least <listPosition> languages
	When the user clicks on the delete language button at <listPosition>
	Then that language should not be displayed on the profile

	Examples: 
    | listPosition |
	| 1            |
	| 2            |
	| 3            |
	| 4            |

@mytag
Scenario: Be unable to delete a language if the language list is empty
	Given a web browser is on the Profile page
	And the Languages tab has been selected
	And the languages list is empty
	Then the delete language button should not be displayed

