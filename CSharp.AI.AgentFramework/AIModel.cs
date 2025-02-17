namespace CSharp.AI.AgentFramework
{
    public class AIModel
    {
        public string Name { get; set; } = "llama3.2:latest";
        public float Temperature { get; set; } = 0.7f;
        public int MaxTokens { get; set; } = 2000;
        public string BaseUrl { get; set; } = "http://localhost:11434";
    }
}
