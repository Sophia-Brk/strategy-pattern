using Strategy.AI.Contracts;
using System.Text;

namespace Strategy.AI.Agents
{
    public class DeepSeekAgent : IAiAgent
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _requestUri;

        public DeepSeekAgent(HttpClient httpClient, string apiKey, string requestUri)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
            _requestUri = requestUri;
        }

        public async Task<string> GenerateResponseAsync(string prompt, string? aiModle)
        {
            var requestBody = new
            {
                prompt = prompt,
                max_tokens = 150 // Adjust as needed
            };

            var request = new HttpRequestMessage(HttpMethod.Post, _requestUri)
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json")
            };
            request.Headers.Add("Authorization", $"Bearer {_apiKey}");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody; // Parse the response as needed
        }
    }
}
