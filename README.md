## C# AI Agents Framework
A lightweight, modular framework for building and managing multi-agent AI systems in C#. This framework enables seamless interaction between multiple AI agents using a local instance of Ollama, providing a foundation for developing collaborative AI applications.

#### **Key Features**
- **Multi-Agent Management**: Easily create, manage, and orchestrate interactions between multiple AI agents.
- **Ollama Integration**: Leverage a local Ollama instance for AI-powered agent communication and decision-making.
- **Modular Design**: Extendable architecture allows for custom agent behaviors, roles, and communication protocols.
- **C# Native**: Built entirely in C#, making it ideal for .NET developers and integrating seamlessly with existing C# ecosystems.
- **Local-First**: Designed to run locally, ensuring privacy and control over your AI agents' interactions.

#### **Use Cases**
- Collaborative AI systems for problem-solving.
- Simulation environments for testing multi-agent interactions.
- AI-driven automation and task delegation.
- Research and experimentation with agent-based AI models.

#### **Getting Started**
1. Clone the repository.
2. Set up a local Ollama instance.
3. Define your agents and their roles using the provided `Agent` class.
4. Use the `MultiAgentManager` to orchestrate interactions between agents.

#### **Example**
```csharp
// Create agents
var agent1 = new Agent("Agent1", "Role1");
var agent2 = new Agent("Agent2", "Role2");

// Add agents to the manager
var manager = new MultiAgentManager();
manager.AddAgent(agent1);
manager.AddAgent(agent2);

// Simulate interaction
manager.SendMessageToAgent("Agent1", "Agent2", "Hello, Agent2!");
```

#### **Why Use This Framework?**
- **Simplicity**: Designed to be easy to use, even for developers new to multi-agent systems.
- **Flexibility**: Customize agent behavior and communication to suit your specific needs.
- **Local AI**: Run everything locally, ensuring data privacy and reducing dependency on external APIs.

#### **Contributing**
Contributions are welcome! Whether it's bug fixes, feature requests, or documentation improvements, feel free to open an issue or submit a pull request.

#### **License**
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---