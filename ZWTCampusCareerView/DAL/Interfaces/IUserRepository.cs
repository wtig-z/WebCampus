using ZWTCampusCareerView.Models;

namespace ZWTCampusCareerView.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task<bool> ValidateCredentialsAsync(string username, string password);
        Task UpdatePasswordAsync(string username, string newPassword); // 确保包含该方法
    }
}
