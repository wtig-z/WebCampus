using System;
using System.Threading.Tasks;
using ZWTCampusCareerView.BLL.Interfaces;
using ZWTCampusCareerView.DAL.Interfaces;
using ZWTCampusCareerView.Models;

namespace ZWTCampusCareerView.BLL
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // 注册方法
        public async Task RegisterAsync(string username, string email, string password)
        {
            // 检查用户名或邮箱是否已存在
            var existingUserByUsername = await _userRepository.GetUserByUsernameAsync(username);
            if (existingUserByUsername != null)
            {
                throw new InvalidOperationException("用户名已存在。");
            }

            var existingUserByEmail = await _userRepository.GetUserByEmailAsync(email);
            if (existingUserByEmail != null)
            {
                throw new InvalidOperationException("邮箱已被注册。");
            }

            // 创建新用户（实际应用中应对密码进行哈希加密）
            var newUser = new User
            {
                Username = username,
                Email = email,
                Password = password
            };

            // 保存用户
            await _userRepository.AddUserAsync(newUser);
        }

        // 登录方法
        public async Task<bool> LoginAsync(string username, string password)
        {
            // 验证用户凭证
            var isValid = await _userRepository.ValidateCredentialsAsync(username, password);
            if (!isValid)
            {
                throw new InvalidOperationException("用户名或密码错误。");
            }
            return true;
        }

        // 修改密码方法
        public async Task ChangePasswordAsync(string username, string oldPassword, string newPassword)
        {
            // 验证用户凭证
            var isValid = await _userRepository.ValidateCredentialsAsync(username, oldPassword);
            if (!isValid)
            {
                throw new InvalidOperationException("旧密码不正确。");
            }

            // 更新密码
            await _userRepository.UpdatePasswordAsync(username, newPassword);
        }
    }
}
