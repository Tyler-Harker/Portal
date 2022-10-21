using NUnit.Framework;
using Orleans.TestKit;
using Portal.Common.ValueObjects;
using Portal.Common.ValueObjects.Organizations;
using Portal.GrainInterfaces;

namespace Portal.Grains.Specs.StepDefinitions
{
    [Binding]
    public class OrganizationGrainDefinitions
    {
        private SiloContext Silo;
        private List<IUserGrain> UserGrains { get; set; }

        public OrganizationGrainDefinitions()
        {
        }
        [BeforeScenario]
        public async Task BeforeScenario()
        {
            this.Silo = new SiloContext();
        }

        [Given("OrganizationGrain with id: (.*) has not been initialized")]
        public async Task GivenOrganizationGrainHasNotBeenInitialized(string id)
        {
            var grain = await Silo.GetGrain(new OrganizationId(id));
        }
        [Given("OrganizationGrain with id: (.*) has been initialized with name: (.*)")]
        public async Task GivenOrganizationGrainHasBeenInitializedWithName(string id, string name)
        {
            var grain = await Silo.GetGrain(new OrganizationId(id));
            await grain.Initialize(new OrganizationName(name));
        }

        [When("OrganizationGrain with id: (.*) GetUsers with Skip: (.*) Take: (.*) is called")]
        public async Task WhenOrganizationGranGetUsersIsCalled(string organizationId, int skip, int take)
        {
            var grain = await Silo.GetGrain(new OrganizationId(organizationId));
            UserGrains = await grain.GetUsers(new SkipTake(skip, take));
        }

        [Then("OrganizationGrain Users has (.*) grain references")]
        public async Task ThenOrganizationGrainUserHasGrainReferences(int number)
        {
            Assert.AreEqual(number, UserGrains.Count());
        }
    }
}