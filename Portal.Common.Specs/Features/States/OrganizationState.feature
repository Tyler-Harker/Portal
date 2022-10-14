Feature: OrganizationState
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](Portal.Common.Specs/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

Scenario: Initial State Id is set
	Given organization state is initialized
	Then the organizations id is set

Scenario: Initial State Name is set
	Given organization state is initialized
	Then the organizations name is set

Scenario: Initial State ActiveUserIds is set
	Given organization state is initialized
	Then the organizations active user ids is set

Scenario: Initial State DeactivatedUserIds is set
	Given organization state is initialized
	Then the organizations deactived user ids is set


Scenario: add new user adds to active user ids list
	Given organization state is initialized
	And organization has the following active user ids
	| Value                                |
	| f9f6c0ba-89bd-4bbf-ac3b-45c9261ca945 |
	| dd926687-06a6-4a5a-b16e-de6b31654839 |
	When a user is added with id: b2a38ba0-8e09-474a-b290-c35941372ff4
	Then active user ids is equal to
	| Value                                |
	| f9f6c0ba-89bd-4bbf-ac3b-45c9261ca945 |
	| dd926687-06a6-4a5a-b16e-de6b31654839 |
	| b2a38ba0-8e09-474a-b290-c35941372ff4 |

@ExpectException
Scenario: add existing user to active user ids list throws exception
	Given organization state is initialized
	And organization has the following active user ids
	| Value                                |
	| f9f6c0ba-89bd-4bbf-ac3b-45c9261ca945 |
	When a user is added with id: f9f6c0ba-89bd-4bbf-ac3b-45c9261ca945
	Then there is an exception of type: UserIdAlreadyExistsInActiveUserIdListException

Scenario: deactivate user removes that user from active user ids list
	Given organization state is initialized
	And organization has the following active user ids
	| Value                                |
	| f9f6c0ba-89bd-4bbf-ac3b-45c9261ca945 |
	| dd926687-06a6-4a5a-b16e-de6b31654839 |
	When a user is deactivated with id: dd926687-06a6-4a5a-b16e-de6b31654839
	Then active user ids is equal to
	| Value                                |
	| f9f6c0ba-89bd-4bbf-ac3b-45c9261ca945 |

Scenario: deactivate user adds that user to the deactivated user ids list
Given organization state is initialized
	And organization has the following active user ids
	| Value                                |
	| f9f6c0ba-89bd-4bbf-ac3b-45c9261ca945 |
	| dd926687-06a6-4a5a-b16e-de6b31654839 |
	When a user is deactivated with id: dd926687-06a6-4a5a-b16e-de6b31654839
	Then deactivated user ids is equal to
	| Value                                |
	| dd926687-06a6-4a5a-b16e-de6b31654839 |

Scenario: SetIdentityProviderConfiguration
	Given organization state is initialized
	When the following identity provider configuration id is set: 00e15ebf-926c-40aa-9ec0-4fe202adb31c
	Then the organizations identity provider config id equals: 00e15ebf-926c-40aa-9ec0-4fe202adb31c

