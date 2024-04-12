using System;
using TechTalk.SpecFlow;
using Tests.Support;

namespace Tests.StepDefinitions
{
    [Binding]
    public class DevopsTestStepDefinitions
    {
        private readonly TestPage? page;

        public DevopsTestStepDefinitions()
        {
            page = new TestPage();
        }

        [Given(@"Access to data endpoint")]
        public void GivenAccessToDataEndpoint()
        {
            page.AccessEndpoint();
            page.GetItem();
        }

        [When(@"Get item with id = (.*)")]
        public void WhenGetItemWithId(int p0)
        {
            throw new PendingStepException();
        }

        [Then(@"Item has to be named '([^']*)'")]
        public void ThenItemHasToBeNamed(string p0)
        {
            throw new PendingStepException();
        }
    }
}
