using SurveySystem.DAL;
using SurveySystem.DAL.Entites;
using SurveySystem.DAL.Repositories.Survey;

namespace SurveySystem.BLL.SurveyService
{
    /// <summary>
    ///  DATA BASE MODELS WILL BE CONVERTED HERE TO DTOs USING ENTITY MAPPER OR MAPSTER
    /// </summary>

    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;

        public SurveyService(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public async Task<IEnumerable<Survey>> GetAllSurveysAsync() => await _surveyRepository.GetSurveysWithQuestionsAsync();

        public async Task<Survey?> GetSurveyByIdAsync(int id) => await _surveyRepository.GetByIdAsync(id);

        public async Task CreateSurveyAsync(Survey survey) => await _surveyRepository.AddAsync(survey);

        public async Task<bool> UpdateSurveyAsync(Survey survey)
        {
            var existingSurvey = await _surveyRepository.GetByIdAsync(survey.Id);
            if (existingSurvey == null) return false;

            existingSurvey.Title = survey.Title;
            existingSurvey.Description = survey.Description;
            await _surveyRepository.UpdateAsync(existingSurvey);
            return true;
        }

        public async Task<bool> DeleteSurveyAsync(int id)
        {
            var existingSurvey = await _surveyRepository.GetByIdAsync(id);
            if (existingSurvey == null) return false;

            await _surveyRepository.DeleteAsync(id);
            return true;
        }
    }

}
