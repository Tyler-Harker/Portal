using NUnit.Framework;
using Portal.Common.GrainStates;
using Portal.Common.ValueObjects.IdentityProviderConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Specs.StepDefinitions.States
{
    [Binding]
    public sealed class IdentityProviderConfigurationStateDefinitions
    {
        private IdentityProviderConfigurationState State;


        [Given("IdentityProviderConfigurationState hasn't been initialized")]
        public async Task GivenStateHasntBeenInitialized()
        {
            State = new IdentityProviderConfigurationState();
        }

        [When("i initialize IdentityProviderConfigurationState as microsoft with TenantId: (.*), Authority: (.*), ClientId: (.*), ClientSecret: (.*)")]
        public async Task WhenIInitializeStateAsMicrosoft(string tenantId, string authority, string clientId, string clientSecret)
        {
            State.Apply(new Events.IdentityProviderConfigurationEvents.InitializeAsMicrosoftEvent(
                new TenantId(tenantId),
                new Authority(authority),
                new ClientId(clientId),
                new ClientSecret(clientSecret)));
        }

        [Then("IdentityProviderConfigurationState tenantId should be: (.*)")]
        public async Task ThenTenantIdShouldBe(string tenantId)
        {
            Assert.AreEqual(new TenantId(tenantId), State.TenantId);
        }

        [Then("IdentityProviderConfigurationState authority should be: (.*)")]
        public async Task ThenAuthorityShouldBe(string authority)
        {
            Assert.AreEqual(new Authority(authority), State.Authority);
        }

        [Then("IdentityProviderConfigurationState clientId should be: (.*)")]
        public async Task ThenClientIdShouldBe(string clientId)
        {
            Assert.AreEqual(new ClientId(clientId), State.ClientId);
        }

        [Then("IdentityProviderConfigurationState clientSecret should be: (.*)")]
        public async Task ThenClientSecretShouldBe(string clientSecret)
        {
            Assert.AreEqual(new ClientSecret(clientSecret), State.ClientSecret);
        }
    }
}
