using RestSharp;

namespace Tests.Support
{
    internal class TestPage
    {
        private RestClient _client;
        private RestResponse _response;

        public void AccessEndpoint()
        {
            _client = new RestClient("http://localhost:5000");
        }

        public void GetItem()
        {
            var request = new RestRequest("api/data", Method.Get);
            _response = _client.Execute(request);
        }
    }
}
