using Microsoft.AspNetCore.Mvc;
using Strategy.AI.Services;

namespace Strategy.AI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AiController : ControllerBase
    {
        private readonly IAiService _aiService;

        public AiController(IAiService aiService)
        {
            _aiService = aiService;
        }

        [HttpGet("ask")]
        public async Task<IActionResult> Ask([FromQuery] string prompt, [FromQuery] string modelType,string? aiModel= "gpt-4")
        {
            var response = await _aiService.GetAiResponseAsync(prompt, modelType, aiModel);
            return Ok(response);
        }
    }
}
