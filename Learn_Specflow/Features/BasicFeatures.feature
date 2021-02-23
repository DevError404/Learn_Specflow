Feature: BasicFeatures
	

@mytag
Scenario: Youtube  
	Given I navigate to the youtube URL
	And I have entered FRIENDS as search keyword
	When I press the search button
	Then I should navigate to search results page

Scenario: Example to show how to read data from excel
	Given I navigate to facebook URL
	Then I enter Email and password