using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace PSSDotNetCore.RestApiWithNLayer.Features.Zodiac
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickAPileController : ControllerBase
    {
        private PickAPile _data;

        private async Task<PickAPile> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("data.json");
            var model = JsonConvert.DeserializeObject<PickAPile>(jsonStr);
            return model;
        }

        [HttpGet("questions")]
        public async Task<IActionResult> Questions()
        {
            var model = await GetDataAsync();
            return Ok(model.Questions);
        }

        [HttpGet("answers")]
        public async Task<IActionResult> AnswerName()
        {
            var model = await GetDataAsync();
            return Ok(model.Answers);
        }

        [HttpGet("{QuestionId}/{AnswerName}")]
        public async Task<IActionResult> Answer(int QuestionId, string AnswerName)
        {
            var model = await GetDataAsync();
            return Ok(model.Answers.FirstOrDefault(x => x.QuestionId == QuestionId && x.AnswerName == AnswerName));
        }
    }


    public class PickAPile
    {
        public Question[] Questions { get; set; }
        public Answer[] Answers { get; set; }
    }

    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public string QuestionDesp { get; set; }
    }

    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerImageUrl { get; set; }
        public string AnswerName { get; set; }
        public string AnswerDesp { get; set; }
        public int QuestionId { get; set; }
    }
}


