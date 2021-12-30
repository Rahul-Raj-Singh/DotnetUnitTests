using System.Net.Http;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class GetJokes
    {
        private readonly HttpClient _httpClient;
        public const string endpoint = "https://icanhazdadjoke.com";
        public const string postEndpoint = "https://httpbin.org/post";
        

        public GetJokes(HttpClient httpClient)
        {
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public JokeDto FetchRandomJoke()
        {
            var jsonString = _httpClient.GetAsync(endpoint).Result.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<JokeDto>(jsonString);
        }

        public int PostGibberish()
        {
            var response = _httpClient.PostAsync(postEndpoint, new StringContent(@"{""data"" : ""Hi There""}")).Result;

            return (int) response.StatusCode;
        }

    }

    public class JokeDto
    {
        public string Id { get; set; }
        public string Joke { get; set; }
        public int Status { get; set; }
    }

}