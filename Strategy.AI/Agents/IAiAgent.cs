namespace Strategy.AI.Contracts
{
    public interface IAiAgent
    {
        Task<string> GenerateResponseAsync(string prompt,string? aiModel);
    }
}
