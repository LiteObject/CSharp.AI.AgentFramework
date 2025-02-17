using Microsoft.Extensions.AI;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace CSharp.AI.AgentFramework
{
    public class AIService(ILogger logger)
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger = logger;

        public async Task<string> GenerateAsync(AIModel model, string prompt)
        {
            using var ollamaClient = new OllamaChatClient(new Uri(model.BaseUrl), model.Name);
            ChatOptions options = new() { Temperature = model.Temperature };
            ChatCompletion response = await ollamaClient.CompleteAsync(prompt, options);

            //OllamaResponse ollamaResponse = new(response?.Message?.Text ?? string.Empty);
            //return ollamaResponse.Response;

            return response?.Message?.Text ?? string.Empty;
        }

        public async Task<string> GenerateAsync(string model, string prompt, double temperature, int maxTokens)
        {
            const int maxRetries = 3;
            var retryCount = 0;

            while (true)
            {
                try
                {
                    var payload = new
                    {
                        model,
                        prompt,
                        temperature,
                        max_tokens = maxTokens
                    };

                    var response = await _client.PostAsJsonAsync("/api/generate", payload);
                    response.EnsureSuccessStatusCode();

                    var result = await response.Content.ReadFromJsonAsync<OllamaResponse>();
                    return result?.Response ?? string.Empty;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ollama API error");
                    if (retryCount >= maxRetries) throw;
                    await Task.Delay(1000 * (int)Math.Pow(2, retryCount));
                    retryCount++;
                }
            }
        }

        private record OllamaResponse(string Response);
    }
}
