using CSharp.AI.AgentFramework.Interfaces;
using Microsoft.Extensions.AI;

namespace CSharp.AI.AgentFramework.Agents
{
    public abstract class AgentBase(string name, string role, string goal, AIModel ollamaModel) : IAgent
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        public string Name { get; init; } = name;
        public string Role { get; init; } = role;        
        public string Goal { get; init; } = goal;
        public AIModel ModelConfig { get; set; } = ollamaModel;
        public List<ITool> Tools { get; } = [];

        public virtual async Task<string> SendMessageAsync(string message)
        {
            // using HttpClient client = new();
            // Prepare the request payload
            //var payload = new { message };
            //string jsonPayload = System.Text.Json.JsonSerializer.Serialize(payload);
            //StringContent content = new(jsonPayload, Encoding.UTF8, "application/json");

            // Send the request to Ollama
            // HttpResponseMessage response = await client.PostAsync("http://localhost:11434/ollama-endpoint", content);

            // Handle the response
            //if (response.IsSuccessStatusCode)
            //{
            //    string responseBody = await response.Content.ReadAsStringAsync();
            //    return responseBody;
            //}
            //else
            //{
            //    return "Error: Unable to communicate with Ollama.";
            //}

            using var ollamaClient = new OllamaChatClient(new Uri("http://localhost:11434/"), "llama3.2:latest");
            ChatOptions options = new() { Temperature = 0.2f };
            ChatCompletion response = await ollamaClient.CompleteAsync(message, options);

            string responseText = response.Message.Text ?? "";

            return responseText;

        }

        public virtual async Task ReceiveMessageAsync(string message)
        {
            // Default implementation for receiving messages (can be overridden)
            await Task.Delay(100); // Simulate async work
            Console.WriteLine($"{Name} received: {message}");
        }
    }
}
