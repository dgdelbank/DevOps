using NUnit.Framework;
using Tests.Support;

namespace Tests.StepDefinitions
{
    [Binding]
    public class DevopsTestStepDefinitions
    {
        private readonly TestPage? page;
        private dynamic? item;

        public DevopsTestStepDefinitions()
        {
            page = new TestPage();
        }

        [Given(@"Access to data endpoint")]
        public void GivenAccessToDataEndpoint()
        {
            page.AccessEndpoint();
            page.GetResponse();
        }

        [When(@"Get item with id = (.*)")]
        public void WhenGetItemWithId(int p0)
        {
            item = page.GetItem(p0);
        }

        [Then(@"Item has to be named '([^']*)'")]
        public void ThenItemHasToBeNamed(string p0)
        {
            Assert.IsTrue(page.AssertItemHasName(item, p0));
        }
    }
}
