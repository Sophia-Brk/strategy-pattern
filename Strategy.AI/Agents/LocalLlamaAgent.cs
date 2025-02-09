using Strategy.AI.Contracts;
namespace Strategy.AI.Agents;
public class LocalLlamaAgent : IAiAgent
{
    public async Task<string> GenerateResponseAsync(string prompt, string? aiModel)
    {
        // Simulate interaction with a local LLM
        await Task.Delay(100); // Simulate processing time
        return $"Local LLM response to: {prompt}";
    }
}
