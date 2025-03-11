using SurveySystem.DAL.Entites;

namespace SurveySystem.BLL.UserService
{
    public interface IUserService
    {
        Task<User> AddUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
        Task<User?> GetUserByIdAsync(int userId);
    }
}
