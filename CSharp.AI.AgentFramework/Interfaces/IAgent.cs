namespace CSharp.AI.AgentFramework.Interfaces
{
    public interface IAgent
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Role { get; init; }
        public string Goal { get; init; }

        public AIModel ModelConfig { get; set; }
        public List<ITool> Tools { get; }

        //Task<string> SendMessageAsync(string message);
        //Task ReceiveMessageAsync(string message);
    }
}
