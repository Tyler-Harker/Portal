using Orleans.TestKit;
using Portal.Common.ValueObjects.Organizations;
using Portal.GrainInterfaces;

namespace Portal.Grains.Specs.StepDefinitions
{
    [Binding]
    public class OrganizationGrainDefinitions
    {
        private readonly TestKitSilo Silo;
        public OrganizationGrainDefinitions()
        {
            Silo = new TestKitSilo();
        }

        [Given("OrganizationGrain with id: (.*) has not been initialized")]
        public async Task GivenOrganizationGrainHasNotBeenInitialized(string id)
        {
            await Silo.CreateGrainAsync<OrganizationGrain>(id);
        }

        [When("OrganizationGrain with id: (.*) GetUsers with Skip: (.*) Take: (.*) is called")]
        public async Task WhenOrganizationGranGetUsersIsCalled(string organizationId, int skip, int take)
        {
            var result = await Silo.GrainFactory.GetGrain(new OrganizationId(organizationId)).GetUsers(new Common.ValueObjects.SkipTake(skip, take));
        }
    }
}