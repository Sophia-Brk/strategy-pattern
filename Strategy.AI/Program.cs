using Strategy.AI;
using Strategy.AI.Agents;
using Strategy.AI.Services;

var builder = WebApplication.CreateBuilder(args);

// Register the AI agents
builder.Services.AddTransient<OpenAiGptAgent>(sp => new OpenAiGptAgent(new HttpClient(), builder.Configuration["OpenAiApiKey"]!
    , builder.Configuration["OpenAiEndpoint"]!));
builder.Services.AddTransient<DeepSeekAgent>(sp => new DeepSeekAgent(new HttpClient(),
    builder.Configuration["DeepSeekApiKey"]!, builder.Configuration["DeepSeekApiUrl"]!));
builder.Services.AddTransient<LocalLlamaAgent>();

// Register the delegate
builder.Services.AddTransient<AiAgentResolver>(serviceProvider => modelType =>
{
    return modelType switch
    {
        "OpenAI" => serviceProvider.GetRequiredService<OpenAiGptAgent>(),
        "DeepSeek" => serviceProvider.GetRequiredService<DeepSeekAgent>(),
        "Local" => serviceProvider.GetRequiredService<LocalLlamaAgent>(),
        _ => throw new ArgumentException("Invalid AI model type")
    };
});
// Add services to the container.
builder.Services.AddTransient<IAiService, AiService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
