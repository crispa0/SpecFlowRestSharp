Feature: POST endpoint tests

Scenario Outline: Trigger POST url endpoint and retrieve Status Codes and updated Contents
	Given I executed POST with "<endpoint>" with username "<name>" and job "<job>"
	Then the Status Code from POST call should be <statusCode>
	And the updated payload after POST call should be "<name>" "<job>"
Examples: 
| endpoint | statusCode | name      | job           |
| users/2  | 201        | morpheus  | zion resident |
| users/2  | 201        | cris      | staff         |
| users/2  | 201        | test cris | administrator |