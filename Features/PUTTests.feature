Feature: PUT endpoint tests

Scenario Outline: Trigger PUT url endpoint and retrieve Status Codes and updated Contents
	Given I executed PUT with "<endpoint>" "<name>" "<job>"
	Then the Status Code from PUT call should be <statusCode>
	And the updated payload after PUT call should be "<name>" "<job>"
Examples: 
| endpoint | statusCode | name      | job           |
| users/2  | 200        | morpheus  | zion resident |
| users/2  | 200        | cris      | staff         |
| users/2  | 200        | test cris | administrator |