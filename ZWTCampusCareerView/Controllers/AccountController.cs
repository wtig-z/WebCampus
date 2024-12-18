using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZWTCampusCareerView.BLL.Interfaces;
using ZWTCampusCareerView.ViewModels;

namespace ZWTCampusCareerView.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // 注册接口
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                await _accountService.RegisterAsync(request.Username, request.Email, request.Password);
                return Ok("注册成功。");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "服务器发生错误。");
            }
        }

        // 登录接口
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                await _accountService.LoginAsync(request.Username, request.Password);
                return Ok("登录成功。");
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch
            {
                return StatusCode(500, "服务器发生错误。");
            }
        }

        // 修改密码接口
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            try
            {
                await _accountService.ChangePasswordAsync(request.Username, request.OldPassword, request.NewPassword);
                return Ok("密码修改成功。");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "服务器发生错误。");
            }
        }
    }
}
