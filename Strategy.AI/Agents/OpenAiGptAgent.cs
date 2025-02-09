using System.Text;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Strategy.AI.Contracts;

namespace Strategy.AI.Agents;
public class OpenAiGptAgent : IAiAgent
{
   private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _requestUri;

    public OpenAiGptAgent(HttpClient httpClient, string apiKey, string requestUri)
    {
        _httpClient = httpClient;
        _apiKey = apiKey;
        _requestUri = requestUri;
    }

    public async Task<string> GenerateResponseAsync(string prompt,string? aiModel)
    {

        var requestBody = new
        {
            model = aiModel,
            messages = new[]
           {
                new { role = "system", content = "You are a helpful assistant." },
                new { role = "user", content = "Hello!" }
            }
        };
        var json = System.Text.Json.JsonSerializer.Serialize(requestBody);


        var content = new StringContent(json, Encoding.UTF8, "application/json");

        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

        try
        {
            var response = await _httpClient.PostAsync(_requestUri, content);
            response.EnsureSuccessStatusCode(); // Throws an exception if the status code is not successful

            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Response:");
            Console.WriteLine(responseBody);
            return responseBody; // Parse the response as needed

        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("Request error:");
            Console.WriteLine(e.Message);
            return "";
        }
    }
}

