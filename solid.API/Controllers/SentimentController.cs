using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using solid.Models.ViewModels;
using solid.Services.Interfaces;

namespace solid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentimentController : ControllerBase
    {
        private readonly ISentimentService _sentimentService;

        public SentimentController(ISentimentService sentimentService)
        {
            _sentimentService = sentimentService;
        }
        [HttpGet("GetAllSentiments")]
        public async Task<IActionResult> GetAllSentiments()
        {
            List<SentimentModel> sentimentModels = await _sentimentService.GetAllSentiments();
            return Ok(sentimentModels);
        }
        [HttpPost("CreateSentiment")]
        public async Task<IActionResult> CreateSentiment([FromBody] SentimentModel sentimentModel)
        {
            if (sentimentModel == null)
            {
                return BadRequest("Text data is required.");
            }
            SentimentModel createdSentiment = await _sentimentService.CreateSentiment(sentimentModel);
            return Ok(createdSentiment);
        }

    }
}
