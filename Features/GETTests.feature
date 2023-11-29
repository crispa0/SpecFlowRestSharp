Feature: GET endpoint tests

Scenario Outline: Trigger GET url endpoints for single user and retrieve Status Codes and Contents
	Given I executed GET with <endpoint>
	Then the Status Code should be <statusCode>
	And the payload should be <firstName> <lastName> <email>
Examples: 
| endpoint | statusCode | firstName | lastName | email                  |
| users/1  | 200        | George    | Bluth    | george.bluth@reqres.in |
| users/2  | 200        | Janet     | Weaver   | janet.weaver@reqres.in |
| users/23 | 404        |           |          |                        |

Scenario Outline: Trigger GET url endpoints for list of users and retrieve Status Codes and Contents
	Given I executed GET with <endpoint>
	Then the Status Code should be <statusCode>
	And the payload for the list should be <pageNum> <totalData> <dataPerPage>
Examples: 
| endpoint		 | statusCode | pageNum | totalData | dataPerPage |
| users?page=1	 | 200        | 1	    | 12		| 6			  |
| users?page=2	 | 200        | 2       | 12	    | 6			  |