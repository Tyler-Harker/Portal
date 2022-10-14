Feature: OrganizationGrain

@ExpectException
Scenario: GetUserIdsThrowsExceptionWhenNotInitialized
	Given OrganizationGrain with id: test has not been initialized
	When OrganizationGrain with id: test GetUsers with Skip: 0 Take: 10 is called
	Then there is an exception of type: GrainNotInitializedException

