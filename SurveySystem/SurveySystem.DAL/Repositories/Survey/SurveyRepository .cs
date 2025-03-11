using Microsoft.EntityFrameworkCore;
using SurveySystem.DAL.DataContext;
using SurveySystem.DAL.Entites;

namespace SurveySystem.DAL.Repositories.Survey
{
    public class SurveyRepository : Repository<Entites.Survey>, ISurveyRepository
    {
        private readonly SurveyDbContext _context;

        public SurveyRepository(SurveyDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Entites.Survey>> GetSurveysWithQuestionsAsync()
        {
            return await _context.Surveys.Include(s => s.Questions).ToListAsync();
        }
    }

}
