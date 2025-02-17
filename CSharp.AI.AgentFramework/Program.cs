using CSharp.AI.AgentFramework.Agents;
using CSharp.AI.AgentFramework.Interfaces;
using CSharp.AI.AgentFramework.Tools;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace CSharp.AI.AgentFramework
{
    internal class Program
    {
        static async Task Main()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSimpleConsole(opts =>
                {
                    opts.ColorBehavior = LoggerColorBehavior.Enabled;
                    opts.TimestampFormat = "HH:mm:ss ";
                });
            });

            AIModel model = new();
            AIService aiService = new(loggerFactory.CreateLogger<AIService>());

            // Add agents to the manager
            var hub = new AgentHub(aiService, loggerFactory.CreateLogger<AgentHub>());

            // Create Tasks
            var researchTask = new MyTask
            {
                Description = "Investigate AI advancements in Q4 2022",
                ExpectedOutput = "Bulleted list of 10 key points",
                Tools = { new WebSearchTool() }
            };

            var researcher = new TaskAgent("ResearchAgent", "Senior Researcher", "Uncover cutting-edge AI trends", model);

            hub.AddAgent(researcher).AddTask(researchTask);

            var results = await hub.ExecuteAsync();

            foreach (var(key, value) in results) 
            {
                Console.WriteLine($"Task {key}:");
                Console.WriteLine(value);
            }
        }
    }
}
