using NUnit.Framework;
using Portal.Common.JsonConverters;
using Portal.Common.ValueObjects;
using Portal.Common.ValueObjects.IdentityProviderConfigurations;
using Portal.Common.ValueObjects.Organizations;
using SpecFlow.Internal.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Portal.Common.Specs.StepDefinitions.ValueObjects
{
    [Binding]
    public sealed class BaseValueObjectSteps
    {
        private TestGenericStringBaseValueObject StringState;
        private TestGenericIntBaseValueObject IntState;
        private JsonSerializerOptions SerializerDefaults;
        private string StateJson = "";

        public BaseValueObjectSteps()
        {
            SerializerDefaults = new JsonSerializerOptions().AddCustomJsonConverters();

        }

        [Given("BaseValueObject<string> is initialized with value: \"(.*)\"")]
        public async Task GivenBaseValueObjectIsInitializedAsString(string value)
        {
            StringState = new TestGenericStringBaseValueObject(value);
        }
        [Given("BaseValueObject<string> has the json value: \"(.*)\"")]
        public async Task GivenBaseValueObjectStringHasTheJsonValue(string json)
        {
            StateJson = json;
        }

        [Given("BaseValueObject<int> is initialized with value: (.*)")]
        public async Task GivenBaseValueObjectIsInitizliaedWithValue(int value)
        {
            IntState = new TestGenericIntBaseValueObject(value);
        }

        [Then("BaseValueObject<string> to json returns: (.*)")]
        public async Task ThenBaseValueObjectToJsonMethodReturns(string json)
        {
            Assert.AreEqual(json, JsonSerializer.Serialize(StringState, SerializerDefaults));
        }
        [Then("BaseValueObject<string> from json returns with value: \"(.*)\"")]
        public async Task ThenBaseValueObjectStringFromJsonReturnsWithValue(string value)
        {
            var obj = new TestGenericStringBaseValueObject(value);
            Assert.AreEqual(value, obj.Value);
        }
        [Then("BaseValueObject<int> to json returns: \"(.*)\"")]
        public async Task ThenBaseValueObjectToJsonReturns(string json)
        {
            Assert.AreEqual(json, JsonSerializer.Serialize(IntState, SerializerDefaults));
        }
    }


    internal class TestGenericStringBaseValueObject : BaseValueObject<string>
    {
        public TestGenericStringBaseValueObject(string value) : base(value)
        {
        }
    }
    internal class TestGenericIntBaseValueObject : BaseValueObject<int>
    {
        public TestGenericIntBaseValueObject(int value) : base(value)
        {

        }
    }
}
