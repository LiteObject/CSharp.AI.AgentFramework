using CSharp.AI.AgentFramework.Interfaces;
using Microsoft.Extensions.Logging;
using System.Text;

namespace CSharp.AI.AgentFramework
{
    public class AgentHub(AIService ollama, ILogger<AgentHub> logger)
    {
        private readonly List<IAgent> _agents = [];
        private readonly List<MyTask> _tasks = [];
        private readonly AIService _ollama = ollama;
        private readonly Context _context = [];
        private readonly ILogger _logger = logger;

        public AgentHub AddAgent(IAgent agent)
        {
            _agents.Add(agent);
            return this;
        }

        public AgentHub AddTask(MyTask task)
        {
            _tasks.Add(task);
            return this;
        }

        private bool AreDependenciesMet(MyTask task, HashSet<string> completedTasks)
        {
            return task.DependentOn.All(d => completedTasks.Contains(d));
        }

        public async Task<Context> ExecuteAsync()
        {
            var taskQueue = new Queue<MyTask>(_tasks);
            var completedTasks = new HashSet<string>();

            while (taskQueue.Count > 0)
            {
                var currentTask = taskQueue.Dequeue();

                if (!AreDependenciesMet(currentTask, completedTasks))
                {
                    taskQueue.Enqueue(currentTask);
                    continue;
                }

                _logger.LogInformation("Executing task: {TaskId}", currentTask.Id);

                var result = await ProcessTask(currentTask);
                _context[currentTask.Id] = result;

                completedTasks.Add(currentTask.Id);
                _logger.LogInformation("Completed task: {TaskId}", currentTask.Id);
            }

            return _context;
        }

        private async Task<string> ProcessTask(MyTask task)
        {
            // Execute tools first
            StringBuilder toolResults = new ();

            foreach (var tool in task.Tools)
            {
                toolResults.AppendLine(await tool.ExecuteAsync(_context, task.Description));
            }

            // Get best agent for the task
            // TODO: implement actual agent selection
            // Simplified implementation
            var agent = _agents.First(); 

            // Build final prompt
            var prompt = $"""
                Role: {agent.Role}
                Goal: {agent.Goal}
                Task: {task.Description}
                Context: {toolResults}
                Output format: {task.ExpectedOutput}
                """;

            return await _ollama.GenerateAsync(
                agent.ModelConfig,
                prompt
            );
        }
    }
}
