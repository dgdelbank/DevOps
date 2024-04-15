using Newtonsoft.Json;
using RestSharp;

namespace Tests.Support
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    internal class TestPage
    {
        private RestClient _client;
        private RestResponse _response;

        public void AccessEndpoint()
        {
            _client = new RestClient("http://localhost:5000");
        }

        public void GetResponse()
        {
            var request = new RestRequest("api/data", Method.Get);
            _response = _client.Execute(request);
        }

        public string GetItem(int id)
        {
            var content = _response.Content;

            var items = JsonConvert.DeserializeObject<List<Item>>(content);

            foreach (var item in items)
            {
                if (item.Id == id)
                {
                    var name = item.Name;
                    return name;
                }
                else
                {
                    throw new Exception("Item não encontrado!");
                }
            }
            return null;
        }

        public bool AssertItemHasName(string item, string name)
        {
            if (item == name)
            {
                return true;
            }
            else { return false; }
        }
    }
}
