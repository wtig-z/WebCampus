using System.Threading.Tasks;

namespace ZWTCampusCareerView.BLL.Interfaces
{
    public interface IAccountService
    {
        Task RegisterAsync(string username, string email, string password);
        Task<bool> LoginAsync(string username, string password);
        Task ChangePasswordAsync(string username, string oldPassword, string newPassword);
    }
}
