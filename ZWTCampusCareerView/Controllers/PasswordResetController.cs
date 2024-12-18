using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
namespace ZWTCampusCareerView.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordResetController : ControllerBase
    {
        // POST: api/PasswordReset
        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            // 验证用户名和邮箱是否匹配（此处省略，因不涉及数据库）

            // 生成新密码
            var newPassword = GenerateNewPassword();

            // 将新密码发送到用户的邮箱
            await SendEmailAsync(request.Email, newPassword);

            // 返回成功响应
            return Ok("新密码已发送到您的邮箱。");
        }
        // 生成随机密码的方法
        private string GenerateNewPassword()
        {
            // 为了简单，此处返回固定密码；实际应用中应生成随机密码
            return "NewPassword123!";
        }
        // 发送邮件的方法
        private async Task SendEmailAsync(string email, string newPassword)
        {
            // 配置SMTP客户端（使用网易邮箱）
            var smtpClient = new SmtpClient("smtp.163.com")
            {
                Port = 25, // 使用 SSL，端口号为 465
                Credentials = new NetworkCredential("18718467433@163.com", "CTkqee9PJcNkuVFi"),
                EnableSsl = true, // 使用 SSL
            };
            // 创建邮件内容
            var mailMessage = new MailMessage
            {
                From = new MailAddress("18718467433@163.com"),
                Subject = "密码重置",
                Body = $"您的新密码是：{newPassword}",
                IsBodyHtml = false,
            };
            mailMessage.To.Add(email);
            try
            {
                // 发送邮件
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (SmtpException ex)
            {
                // 记录 SMTP 异常信息
                Console.WriteLine($"SMTP 异常：{ex.Message}");
                // 返回服务器错误响应
                throw new InvalidOperationException("发送邮件失败：" + ex.Message);
            }
            catch (Exception ex)
            {
                // 记录一般异常信息
                Console.WriteLine($"一般异常：{ex.Message}");
                throw new InvalidOperationException("发生错误：" + ex.Message);
            }
        }
    }
// 请求模型
    public class ResetPasswordRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
