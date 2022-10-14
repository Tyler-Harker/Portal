Feature: IdentityProviderConfigurationState

A short summary of the feature

Scenario: InitializeMicrosoft sets TenantId
	Given IdentityProviderConfigurationState hasn't been initialized
	When i initialize IdentityProviderConfigurationState as microsoft with TenantId: "test tenant id", Authority: "https://login.microsoft.com/", ClientId: "test client id, ClientSecret: "test client secret"
	Then IdentityProviderConfigurationState tenantId should be: "test tenant id"

Scenario: InitializeMicrosoft sets Authority
	Given IdentityProviderConfigurationState hasn't been initialized
	When i initialize IdentityProviderConfigurationState as microsoft with TenantId: "test tenant id", Authority: "https://login.microsoft.com/", ClientId: "test client id, ClientSecret: "test client secret"
	Then IdentityProviderConfigurationState authority should be: "https://login.microsoft.com/"

Scenario: InitializeMicrosoft sets ClientId
	Given IdentityProviderConfigurationState hasn't been initialized
	When i initialize IdentityProviderConfigurationState as microsoft with TenantId: "test tenant id", Authority: "https://login.microsoft.com/", ClientId: "test client id", ClientSecret: "test client secret"
	Then IdentityProviderConfigurationState clientId should be: "test client id"

Scenario: InitializeMicrosoft sets ClientSecret
	Given IdentityProviderConfigurationState hasn't been initialized
	When i initialize IdentityProviderConfigurationState as microsoft with TenantId: "test tenant id", Authority: "https://login.microsoft.com/", ClientId: "test client id, ClientSecret: "test client secret"
	Then IdentityProviderConfigurationState clientSecret should be: "test client secret"