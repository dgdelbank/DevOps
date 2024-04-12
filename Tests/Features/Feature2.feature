Feature: devopsTest

@CT02
Scenario: @CT0s_Verify first item from list
	Given Access to data endpoints
	When Get item with ids = 1
	Then Item has to be nameds 'Item 1'
