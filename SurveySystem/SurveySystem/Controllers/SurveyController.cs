using Microsoft.AspNetCore.Mvc;
using SurveySystem.BLL.SurveyService;
using SurveySystem.DAL.Entites;

namespace SurveySystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        // 1️⃣ Get All Surveys
        [HttpGet]
        public async Task<IActionResult> GetAllSurveys()
        {
            var surveys = await _surveyService.GetAllSurveysAsync();
            return Ok(surveys);
        }

        // 2️⃣ Get Survey by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurveyById(int id)
        {
            var survey = await _surveyService.GetSurveyByIdAsync(id);
            if (survey == null) return NotFound();
            return Ok(survey);
        }

        // 3️⃣ Create New Survey
        [HttpPost]
        public async Task<IActionResult> CreateSurvey([FromBody] Survey survey)
        {
            await _surveyService.CreateSurveyAsync(survey);
            return CreatedAtAction(nameof(GetSurveyById), new { id = survey.Id }, survey);
        }

        // 4️⃣ Update Survey
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSurvey(int id, [FromBody] Survey survey)
        {
            if (id != survey.Id) return BadRequest();

            bool updated = await _surveyService.UpdateSurveyAsync(survey);
            if (!updated) return NotFound();

            return NoContent();
        }

        // 5️⃣ Delete Survey
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            bool deleted = await _surveyService.DeleteSurveyAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}