using SurveySystem.DAL;
using SurveySystem.DAL.Entites;

namespace SurveySystem.BLL.SurveyService
{
    public interface ISurveyService
    {
        Task<IEnumerable<Survey>> GetAllSurveysAsync();
        Task<Survey?> GetSurveyByIdAsync(int id);
        Task CreateSurveyAsync(Survey survey);
        Task<bool> UpdateSurveyAsync(Survey survey);
        Task<bool> DeleteSurveyAsync(int id);
    }
}
