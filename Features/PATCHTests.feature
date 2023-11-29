Feature: PATCH endpoint tests

Scenario Outline: Trigger PATCH url endpoint and retrieve Status Codes and updated Contents
	Given I executed PATCH with "<endpoint>" "<name>" "<job>"
	Then the Status Code from PATCH call should be <statusCode>
	And the updated payload after PATCH call should be "<name>" "<job>"
Examples: 
| endpoint | statusCode | name      | job           |
| users/2  | 200        | morpheus  | zion resident |
| users/2  | 200        | cris      | staff         |
| users/2  | 200        | test cris | administrator |