using SurveySystem.DAL.Entites;

namespace SurveySystem.DAL.Repositories.UserRepo
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
        Task<User?> GetUserByIdAsync(int userId);
    }
}