namespace Strategy.AI.Services
{
    public class AiService : IAiService
    {
        private readonly AiAgentResolver _aiAgentResolver;

        public AiService(AiAgentResolver aiAgentResolver)
        {
            _aiAgentResolver = aiAgentResolver;
        }

        public async Task<string> GetAiResponseAsync(string prompt, string modelType, string? aiModel)
        {
            // Resolve the appropriate AI agent
            var aiAgent = _aiAgentResolver(modelType);

            // Use the agent to generate a response
            return await aiAgent.GenerateResponseAsync(prompt, aiModel);
        }
    }
}
