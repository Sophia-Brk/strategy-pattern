namespace Strategy.AI.Services
{
    public interface IAiService
    {
        Task<string> GetAiResponseAsync(string prompt, string modelType,string? model);
    }
}
