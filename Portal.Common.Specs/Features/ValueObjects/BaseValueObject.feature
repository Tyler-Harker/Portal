Feature: BaseValueObject

A short summary of the feature

Scenario: Generic ValueObject of type string returns json as expected
	Given BaseValueObject<string> is initialized with value: "test string"
	Then BaseValueObject<string> to json returns: "test string"

Scenario: Generic ValueObject of type int returns json as expected
	Given BaseValueObject<int> is initialized with value: 10
	Then BaseValueObject<int> to json returns: "10"

Scenario: Generic BaseValueObject<string> from json returns object as expected
	Given BaseValueObject<string> has the json value: "test"
	Then BaseValueObject<string> from json returns with value: "test"