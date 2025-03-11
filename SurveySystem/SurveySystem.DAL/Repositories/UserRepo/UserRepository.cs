using SurveySystem.DAL.DataContext;
using SurveySystem.DAL.Entites;

namespace SurveySystem.DAL.Repositories.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly SurveyDbContext _context;

        public UserRepository(SurveyDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }
    }
}
