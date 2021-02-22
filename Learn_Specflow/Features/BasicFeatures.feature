Feature: BasicFeatures
	

@mytag
Scenario: Setup 
	Given I navigate to the youtube URL
	And I have entered FRIENDS as search keyword
	When I press the search button
	Then I should navigate to search results page