using NUnit.Framework;
using Portal.Common.Events.OrganizationEvents;
using Portal.Common.GrainStates;
using Portal.Common.ValueObjects.IdentityProviderConfigurations;
using Portal.Common.ValueObjects.Organizations;
using Portal.Common.ValueObjects.Users;
using TechTalk.SpecFlow.Assist;

namespace Portal.Common.Specs.StepDefinitions.States
{
    [Binding]
    public sealed class OrganizationStateDefinitions
    {
        private OrganizationState State;


        [Given("organization state is initialized")]
        public async Task GivenOrganizationStateIsInitialized()
        {
            State = new OrganizationState();
            State.Apply(
                new InitializeEvent(
                    new OrganizationId("test"),
                    new OrganizationName("Test")
                )
            );
        }

        [Given("organization has the following active user ids")]
        public async Task GivenOrganizationStateIsInitializedWithTheFollowingActiveUsers(Table table)
        {
            IEnumerable<UserId> userIds = table.CreateSet<UserId>();
            foreach (var userId in userIds)
            {
                State.Apply(new AddUserEvent(userId));
            }
        }
        [Given("organization has the following deactivated user ids")]
        public async Task GivenOrganizationStateIsInitializedWithTheFollowingDeactivatedUsers(Table table)
        {
            IEnumerable<UserId> userIds = table.CreateSet<UserId>();
            foreach (var userId in userIds)
            {
                State.Apply(new AddUserEvent(userId));
            }
            foreach (var userId in userIds)
            {
                State.Apply(new DeactivateUserEvent(userId));
            }
        }

        [When("a user is added with id: (.*)")]
        public async Task WhenAUserIsAddedWithId(Guid id)
        {
            State.Apply(new AddUserEvent(new UserId(id)));
        }
        [When("a user is deactivated with id: (.*)")]
        public async Task WhenAUserIsDeactivatedWithId(Guid id)
        {
            State.Apply(new DeactivateUserEvent(new UserId(id)));
        }

        [When("the following identity provider configuration id is set: (.*)")]
        public async Task WhenTheFollowingIdentityProviderConfigurationIsSet(Guid id)
        {
            State.Apply(new SetIdentityProviderConfigurationIdEvent(new IdentityProviderConfigurationId(id)));
        }

        [Then("the organizations id is set")]
        public async Task ThenTheOrganizationsIdIsSet()
        {
            Assert.NotNull(State.Id);
        }

        [Then("the organizations name is set")]
        public async Task ThenTheOrganizationsNameIsSet()
        {
            Assert.NotNull(State.Name);
        }

        [Then("the organizations active user ids is set")]
        public async Task ThenTheOrganizationsActiveUserIdsIsSet()
        {
            Assert.NotNull(State.ActiveUserIds);
        }

        [Then("the organizations deactived user ids is set")]
        public async Task ThenTheOrganizationsDeactivatedUserIdsIsSet()
        {
            Assert.NotNull(State.DeactivatedUserIds);
        }

        [Then("active user ids is equal to")]
        public async Task ThenActiveUserIdsIsEqualTo(Table table)
        {
            var userIds = table.CreateSet<UserId>();
            Assert.AreEqual(userIds.Count(), State.ActiveUserIds.Count());
            foreach (var userId in userIds)
            {
                Assert.True(State.ActiveUserIds.Contains(userId));
            }
        }

        [Then("deactivated user ids is equal to")]
        public async Task ThenDeactivatedUserIdsIsEqualTo(Table table)
        {
            var userIds = table.CreateSet<UserId>();
            Assert.AreEqual(userIds.Count(), State.DeactivatedUserIds.Count());
            foreach (var userId in userIds)
            {
                Assert.True(State.DeactivatedUserIds.Contains(userId));
            }
        }



        [Then("the organizations identity provider config id equals: (.*)")]
        public async Task ThenTheOrganizationsIdentityProviderConfigEquals(Guid id)
        {
            Assert.AreEqual(new IdentityProviderConfigurationId(id), State.IdentityProviderConfigurationId);
        }

    }
}