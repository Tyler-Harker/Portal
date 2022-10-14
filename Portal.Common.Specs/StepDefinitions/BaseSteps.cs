using NUnit.Framework;
using Portal.Common.Specs.TableModels;
using Portal.Common.ValueObjects;
using Portal.Common.ValueObjects.IdentityProviderConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Bindings;

namespace Portal.Common.Specs.StepDefinitions
{
    [Binding]
    public sealed class BaseSteps
    {
        protected readonly ScenarioContext _scenarioContext;
        public BaseSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [AfterStep("ExpectException")]
        public void ExpectException()
        {
            if(_scenarioContext.StepContext.StepInfo.StepDefinitionType == StepDefinitionType.When)
            {
                var scenarioExecutionStatusProperty = typeof(ScenarioContext).GetProperty(nameof(ScenarioContext.ScenarioExecutionStatus), System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                scenarioExecutionStatusProperty.SetValue(this._scenarioContext, ScenarioExecutionStatus.OK);
            }
        }

        [Then("there is an exception of type: (.*)")]
        public async Task ThenThereIsAnExceptionOfType(string type)
        {
            Assert.NotNull(this._scenarioContext.TestError);
            Assert.AreEqual(type, this._scenarioContext.TestError.GetType().Name);
        }


        [StepArgumentTransformation]
        public IEnumerable<IdentityProviderConfigurationId> GetIdentityProviderConfigurationIds(Table table)
        {
            List<IdentityProviderConfigurationId> ids = new List<IdentityProviderConfigurationId>();
            var rows = table.CreateSet<string>();
            foreach(var row in rows)
            {
                ids.Add(new IdentityProviderConfigurationId(new Guid(row)));
            }
            return ids;
        }

    }
}
