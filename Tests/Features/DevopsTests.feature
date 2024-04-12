Feature: devopsTest

@CT01
Scenario: @CT01_Verify first item from list
	Given Access to data endpoint
	When Get item with id = 1
	Then Item has to be named 'Item 1'
