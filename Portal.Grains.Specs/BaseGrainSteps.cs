using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Bindings;

namespace Portal.Grains.Specs
{
    [Binding]
    public class BaseGrainSteps
    {
        protected readonly ScenarioContext _scenarioContext;
        public BaseGrainSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            
        }

        [Then("there is an exception of type: (.*)")]
        public async Task ThenThereIsAnExceptionOfType(string type)
        {
            Assert.NotNull(this._scenarioContext.TestError);
            Assert.AreEqual(type, this._scenarioContext.TestError.GetType().Name);
        }


        [AfterStep("ExpectException")]
        public void ExpectException()
        {
            if (_scenarioContext.StepContext.StepInfo.StepDefinitionType == StepDefinitionType.When)
            {
                var scenarioExecutionStatusProperty = typeof(ScenarioContext).GetProperty(nameof(ScenarioContext.ScenarioExecutionStatus), System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                scenarioExecutionStatusProperty.SetValue(this._scenarioContext, ScenarioExecutionStatus.OK);
            }
        }
    }
}
