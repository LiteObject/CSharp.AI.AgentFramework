using CSharp.AI.AgentFramework.Interfaces;

namespace CSharp.AI.AgentFramework
{
    public class MyTask
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public string Description { get; set; } = string.Empty;
        public string ExpectedOutput { get; set; } = string.Empty;
        public List<string> DependentOn { get; } = [];
        public List<ITool> Tools { get; } = [];
    }
}
