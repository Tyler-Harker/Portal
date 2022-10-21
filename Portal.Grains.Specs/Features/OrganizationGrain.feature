Feature: OrganizationGrain

@ExpectException
Scenario: GetUserIdsThrowsExceptionWhenNotInitialized
	Given OrganizationGrain with id: test has not been initialized
	When OrganizationGrain with id: test GetUsers with Skip: 0 Take: 10 is called
	Then there is an exception of type: GrainNotInitializedException

Scenario: GetUserIdsReturnsNoResults
	Given OrganizationGrain with id: testing has been initialized with name: Testing
	When OrganizationGrain with id: testing GetUsers with Skip: 0 Take: 10 is called
	Then OrganizationGrain Users has 0 grain references

