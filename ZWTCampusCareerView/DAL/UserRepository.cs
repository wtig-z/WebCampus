using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZWTCampusCareerView.DAL.Interfaces;
using ZWTCampusCareerView.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ZWTCampusCareerView.DAL
{
    public class UserRepository : IUserRepository
    {
        // 静态列表模拟数据存储
        private static List<User> _users = new List<User>
        {
            new User { Id = 1, Username = "testuser", Email = "test@example.com", Password = "password123" }
            // 可以预先添加一些用户
        };

        // 获取用户通过用户名
        public Task<User> GetUserByUsernameAsync(string username)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            return Task.FromResult(user);
        }

        // 获取用户通过邮箱
        public Task<User> GetUserByEmailAsync(string email)
        {
            var user = _users.FirstOrDefault(u => u.Email == email);
            return Task.FromResult(user);
        }

        // 添加新用户
        public Task AddUserAsync(User user)
        {
            user.Id = _users.Max(u => u.Id) + 1; // 生成新的用户ID
            _users.Add(user);
            return Task.CompletedTask;
        }

        // 验证用户凭证
        public Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return Task.FromResult(user != null);
        }

        // 更新密码
        public Task UpdatePasswordAsync(string username, string newPassword)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                user.Password = newPassword;
            }
            return Task.CompletedTask;
        }
    }
}
