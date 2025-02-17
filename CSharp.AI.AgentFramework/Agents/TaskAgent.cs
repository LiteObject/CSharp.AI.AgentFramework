namespace CSharp.AI.AgentFramework.Agents
{
    public class TaskAgent: AgentBase
    {
        public TaskAgent(string name, string role, string goal, AIModel model) : base(name, role, goal, model) { }

        public override async Task<string> SendMessageAsync(string message)
        {
            // Add custom behavior before sending the message
            Console.WriteLine($"{Name} is preparing to send a message: {message}");

            // Call the base class implementation to send the message to Ollama
            string response = await base.SendMessageAsync(message);

            // Add custom behavior after receiving the response
            Console.WriteLine($"{Name} received a response from Ollama: {response}");

            return response;
        }

        public override async Task ReceiveMessageAsync(string message)
        {
            // Custom logic for receiving messages
            await Task.Delay(100); // Simulate async work
            Console.WriteLine($"{Name} (TaskAgent) received task: {message}");
        }
    }
}
