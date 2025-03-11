using SurveySystem.DAL.DataContext;
using SurveySystem.DAL.Entites;

namespace SurveySystem.DAL.Repositories.Survey
{
    public interface ISurveyRepository : IRepository<Entites.Survey>
    {
        Task<List<Entites.Survey>> GetSurveysWithQuestionsAsync();
    }

}
